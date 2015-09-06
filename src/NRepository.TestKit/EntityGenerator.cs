namespace NRepository.TestKit
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class EntityGenerator
    {
        private const int MaxDepthConst = 3;

        private int _currentCount = 1;
        private int _depthCounter = -1;

        public EntityGenerator()
            : this(MaxDepthConst, EntityGeneratorOptions.IgnoreExceptions)
        {
        }

        public EntityGenerator(EntityGeneratorOptions entityGeneratorOptions = EntityGeneratorOptions.IgnoreExceptions)
            : this(MaxDepthConst, entityGeneratorOptions)
        {
        }

        public EntityGenerator(int maxDepth, EntityGeneratorOptions dtoGeneratorOptions = EntityGeneratorOptions.IgnoreExceptions)
        {
            EntityGeneratorOption = dtoGeneratorOptions;
            MaxDepth = maxDepth;
        }

        public EntityGeneratorOptions EntityGeneratorOption
        {
            get;
            private set;
        }

        public int MaxDepth
        {
            get;
            set;
        }

        public static T Create<T>(int maxDepth, EntityGeneratorOptions entityGeneratorOption, params Action<T>[] updates)
        {
            return new EntityGenerator(maxDepth, entityGeneratorOption).CreateEntity<T>(updates);
        }

        public static T Create<T>(EntityGeneratorOptions entityGeneratorOption, params Action<T>[] updates)
        {
            return new EntityGenerator(entityGeneratorOption).CreateEntity<T>(updates);
        }

        public static T Create<T>(int maxDepth, params Action<T>[] updates)
        {
            return new EntityGenerator(maxDepth, EntityGeneratorOptions.IgnoreExceptions).CreateEntity<T>(updates);
        }

        public static T Create<T>(params Action<T>[] updates)
        {
            return new EntityGenerator().CreateEntity<T>(updates);
        }

        public T CreateEntity<T>(params Action<T>[] updates)
        {
            var retVal = (T)CreateEntity(typeof(T));
            updates.ToList().ForEach(action => action(retVal));
            return retVal;
        }

        public object CreateEntity(Type type)
        {
            if (_depthCounter++ >= MaxDepth)
            {
                _depthCounter--;
                return null;
            }

            try
            {
                return CreateInternal(type);
            }
            finally
            {
                _depthCounter--;
            }
        }

        private object CreateInternal(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var genType = type.GetGenericArguments().Single();
                var val = GetValue(genType);
                return val;
            }

            if (type.IsGenericType && typeof(IEnumerable).IsAssignableFrom(type.GetGenericTypeDefinition()))
            {
                var genType = type.GetGenericArguments().Single();
                var obj = CreateInternal(genType);

                var listType = typeof(List<>);
                var constructedListType = listType.MakeGenericType(genType);
                var retValList = Activator.CreateInstance(constructedListType);

                var mi = retValList.GetType().GetMethod("Add");
                mi.Invoke(retValList, new object[] { obj });

                return retValList;
            }

            var retVal = Activator.CreateInstance(type, true);
            AddValues(retVal, retVal.GetType().GetProperties());
            return retVal;
        }

        private void AddValues(object parentObject, PropertyInfo[] properties)
        {
            foreach (var prop in properties)
            {
                var setPrivates = EntityGeneratorOption.HasFlag(EntityGeneratorOptions.SetPrivateProperties);
                if (prop.GetSetMethod(setPrivates) == null)
                {
                    continue;
                }

                SetSingleValue(parentObject, prop);
            }
        }

        private void SetSingleValue(object parentObject, PropertyInfo prop)
        {
            try
            {
                if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(parentObject, prop.Name, null);
                    return;
                }

                if (prop.PropertyType == typeof(DateTime) ||
                    prop.PropertyType == typeof(DateTime?))
                {
                    prop.SetValue(parentObject, DateTime.Today, null);
                    return;
                }

                if (prop.PropertyType == typeof(short) ||
                    prop.PropertyType == typeof(short?))
                {
                    prop.SetValue(parentObject, (short)_currentCount++, null);
                    return;
                }

                if (prop.PropertyType == typeof(int) ||
                    prop.PropertyType == typeof(int?))
                {
                    prop.SetValue(parentObject, _currentCount++, null);
                    return;
                }

                if (prop.PropertyType == typeof(decimal) ||
                    prop.PropertyType == typeof(decimal?))
                {
                    prop.SetValue(parentObject, (decimal)_currentCount++, null);
                    return;
                }

                if (prop.PropertyType.IsEnum)
                {
                    prop.SetValue(parentObject, 1, null);
                    return;
                }

                if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                {
                    var type = prop.PropertyType.IsArray
                        ? prop.PropertyType.GetElementType()
                        : prop.PropertyType.GetGenericArguments().Single();

                    var obj = GetValue(type);
                    if (obj == null)
                    {
                        return;
                    }

                    if (prop.PropertyType.IsArray)
                    {
                        var arrayType = prop.PropertyType.GetElementType();
                        var array = Array.CreateInstance(arrayType, 1);
                        array.SetValue(obj, 0);
                        prop.SetValue(parentObject, array, null);
                        return;
                    }

                    var listType = typeof(List<>);
                    var constructedListType = listType.MakeGenericType(type);
                    var retVal = Activator.CreateInstance(constructedListType);

                    var mi = retVal.GetType().GetMethod("Add");
                    mi.Invoke(retVal, new object[] { obj });

                    prop.SetValue(parentObject, retVal, null);
                    return;
                }

                var val = CreateEntity(prop.PropertyType);
                if (prop.PropertyType.IsGenericType &&
                    prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                    prop.PropertyType.GetGenericArguments().Single().IsEnum)
                {
                    val = null;
                }

                prop.SetValue(parentObject, val, null);
            }
            catch (Exception)
            {
                if (!EntityGeneratorOption.HasFlag(EntityGeneratorOptions.IgnoreExceptions))
                {
                    throw;
                }
            }
        }

        private object GetValue(Type type)
        {
            if (type == typeof(string))
            {
                return typeof(string).Name + _currentCount++;
            }

            if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                return DateTime.Today;
            }

            if (type == typeof(short) || type == typeof(short?))
            {
                return (short)_currentCount++;
            }

            if (type == typeof(int) || type == typeof(int?))
            {
                return _currentCount++;
            }

            if (type == typeof(long) || type == typeof(long?))
            {
                return _currentCount++;
            }

            if (type == typeof(double) || type == typeof(double?))
            {
                return _currentCount++;
            }

            if (type == typeof(float) || type == typeof(float?))
            {
                return _currentCount++;
            }

            if (type == typeof(decimal) || type == typeof(decimal?))
            {
                return (decimal)_currentCount++;
            }

            return type.IsEnum ? 1 : CreateEntity(type);
        }
    }
}
