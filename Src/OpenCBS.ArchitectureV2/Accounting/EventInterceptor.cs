//using System.Collections.Generic;
//using System.ComponentModel.Composition;
//using System.Data.SqlClient;
//using OpenCBS.Extension.Accounting.Repository;
//using OpenCBS.Extension.Accounting.Service;
//using OpenCBS.Extensions;

//namespace OpenCBS.Extension.Accounting
//{
//    [Export(typeof (IEventInterceptor))]
//    [ExportMetadata("Implementation", "Accounting")]
//    [PartCreationPolicy(CreationPolicy.Shared)]
//    public class EventInterceptor : IEventInterceptor
//    {
//        private readonly IBookingService _service;

//        public EventInterceptor()
//        {
//            _service = new BookingService();
//        }

//        public void CallInterceptor(IDictionary<string, object> interceptorParams)
//        {
//            var sqlTransaction = interceptorParams.ContainsKey("SqlTransaction")
//                                     ? (SqlTransaction) interceptorParams["SqlTransaction"]
//                                     : null;
//            if (sqlTransaction == null) return;
//            var repository = new BookingRepository(sqlTransaction.Connection, sqlTransaction);
//            _service.Repository = repository;
//            if (interceptorParams.ContainsKey("Deleted"))
//                _service.DeleteBookingsByEvent(interceptorParams);
//            else _service.SaveBookings(_service.CreateBookings(interceptorParams));
//        }
//    }
//}
