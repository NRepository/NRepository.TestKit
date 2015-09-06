//using NRepository.Core.Events;
//using NRepository.Core.Query;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace NRepository.TestKit
//{
//    public static class IRepositoryQueryEventExtensions
//    {
//        public static void ExpectedStrategies(this GetRepositoryQueryEvent queryEvent, params IQueryStrategy[] strategiesParams)
//        {
//            var expectedStrategies = strategiesParams.ToList();
//            var allQueryStartegyEvents = new List<IQueryStrategy>();

//            allQueryStartegyEvents.Add((IQueryStrategy)queryEvent.Specification);
//            if (queryEvent.QueryStrategy is AggregateQueryStrategy)
//                allQueryStartegyEvents.AddRange(((AggregateQueryStrategy)queryEvent.QueryStrategy).Aggregates);
//            else
//                allQueryStartegyEvents.Add(queryEvent.QueryStrategy);

//            // Assert
//            allQueryStartegyEvents.Count().ShouldEqual(expectedStrategies.Count());
//            for (int i = 0; i < expectedStrategies.Count(); i++)
//            {
//                var expectedStrategy = expectedStrategies[i];
//                var actualStrategy = allQueryStartegyEvents[i];

//                actualStrategy.GetType().ShouldEqual(expectedStrategy.GetType());
//            }
//        }
//    }
//}
