using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        IList<Flight> listFlights = new List<Flight>();

        // avec foreach
        /*
        
        public IList<DateTime> GetFlightDates(string destination)
        {
                List<DateTime> listDates = new List<DateTime>();

                foreach (var flight in listFlights)
                {
                if (flight.Destination == destination)
                    listDates.Add(flight.FlightDate);
                }
                return listDates;
        }
        */

        // avec le langage linq
        /*
          var query = from flight in listFlights
                    where flight.Destination.Equals(destination)
                    select flight.FlightDate;
        ReturnTypeEncoder query.ToList();
         */

        public IList<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();

            foreach (var flight in listFlights)
            {
                if (flight.Destination == destination)
                {
                    dates.Add(flight.FlightDate);
                }


            }
            return dates;
        }


        //ou bien par lambda
        /*
        public IList<DateTime> GetFlightDates(string destination)
        {
           return listFlights.Where (f => f.Destination.Equals(destination))
                             .select (f => f.FlightDate);
        }


        */




        public void ShowFlightDetails(System.Numerics.Plane plane)
        { //linq
            /*
            var query = from flight in listFlights
                        where flight.plane.Equals(plane)
                        select new { flight.FlightDate, flight.Destination };

            */

            //lambda
            var query = listFlights.Where(f => f.Plane.Equals(plane))
                             .Select(f => new { f.FlightDate, f.Destination });


            foreach (var item in query)
            {
                Console.WriteLine(item.FlightDate + item.Destination);
            }





        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            /*
            var endDate = startDate.AddDays(7);
            var query = from flight in listFlights
                        where (flight.FlightDate > startDate) && (flight.FlightDate < endDate)
                        select  flight ;
            return query.Count();
            */
            var endDate = startDate.AddDays(7);
            return listFlights.Where(f => (f.FlightDate > startDate) && (f.FlightDate < endDate))
                             .Select(f => f).Count();
            //najm nahi select ghady toul nhot '.count()'

        }

        public double DurationAverage(string destination)
        {
            /*
            var query = from flight in listFlights
                        where (flight.Destination == destination ) 
                        select flight.EstimatedDuration;
            return query.Average();

            */
            return listFlights.Where(f => (f.Destination == destination))
                             .Average(f => f.EstimatedDuration);

        }

        IEnumerable<Flight> IServiceFlight.OrderedDurationFlights()
        {
            /*
            var query = from flight in listFlights
                        orderby flight.EstimatedDuration descending
                        select flight;

            return query;
            */
            return listFlights.OrderByDescending(f => (f.EstimatedDuration));

        }



        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            var query = from f in flight.Passengers.OfType<Traveller>() // ofType : indique le type d'objet
                        orderby f.BirthDate ascending
                        select f;

            return query.Take(3);

            /* lambda
             return flight.Passengers.OfType<Traveller>().OrderBy(f => f.BirthDate).Take(3);
             */


        }

    }
}
