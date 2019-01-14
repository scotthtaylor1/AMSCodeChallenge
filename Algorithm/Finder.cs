using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _persons;
        private static int _minPersons = 2;

        public Finder(List<Person> persons)
        {
            _persons = persons ?? throw new ArgumentNullException();
        }

        public Result Find(FindTypes findType)
        {
            Result result = new Result();
            if (_persons.Count < _minPersons) return result;
            _persons.Sort((a, b) => a.BirthDate.CompareTo(b.BirthDate));
            var orderedPersons = _persons.OrderBy(a => a.BirthDate).ToList();

            if (findType == FindTypes.Furthest)
            {
                TimeSpan span = _persons.Last().BirthDate.Subtract(orderedPersons.First().BirthDate);
                result = new Result { Difference = span, Person1 = orderedPersons.First(), Person2 = orderedPersons.Last() };
            }
            else
            {
                var processedPersons = new List<Tuple<TimeSpan, Person, Person>>();

                for (int i = 0; i < _persons.Count - 1; i++)
                {
                    TimeSpan span = _persons[i + 1].BirthDate.Subtract(orderedPersons[i].BirthDate);
                    processedPersons.Add(new Tuple<TimeSpan, Person, Person>(span, orderedPersons[i], orderedPersons[i + 1]));

                }
                processedPersons.Sort((a, b) => a.Item1.CompareTo(b.Item1));
                Tuple<TimeSpan, Person, Person> answer = processedPersons.First();
                result = new Result { Difference = answer.Item1, Person1 = answer.Item2, Person2 = answer.Item3 };
            }
            return result;

           // var result = new Result {  Difference = o}
           //     var results = new List<Result>();
           // foreach( Person person in _persons)
           //// for(var i = 0; i < _persons.Count - 1; i++)
           // {
           //     for(var j = i + 1; j < _persons.Count; j++)
           //     {
           //         var result = new Result();
           //         if(_persons[i].BirthDate < _persons[j].BirthDate)
           //         {
           //             result.Person1 = _persons[i];
           //             result.Person2 = _persons[j];
           //         }
           //         else
           //         {
           //             result.Person1 = _persons[j];
           //             result.Person2 = _persons[i];
           //         }
           //         result.Difference = result.Person2.BirthDate - result.Person1.BirthDate;
           //         results.Add(result);
           //     }
           // }

           // if(results.Count < 1)
           // {
           //     return new Result();
           // }

           // Result answer = results[0];
           // foreach(var result in results)
           // {
           //     switch(findType)
           //     {
           //         case FindTypes.Closest:
           //             if(result.Difference < answer.Difference)
           //             {
           //                 answer = result;
           //             }
           //             break;

           //         case FindTypes.Furthest:
           //             if(result.Difference > answer.Difference)
           //             {
           //                 answer = result;
           //             }
           //             break;
           //     }
           // }

           // return answer;
        }
    }
}