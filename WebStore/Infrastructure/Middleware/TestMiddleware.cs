using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Infrastructure.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _Next;
        public TestMiddleware(RequestDelegate Next) => _Next = Next;

        public async Task Invoke(HttpContext context)
        {
            // обработка информации из Context.Request

            /* асинхронный вызов */
            var processing_task = _Next(context);
            // выполнить какие то действия параллельно
            await processing_task; // далее здесь работает оставшаяся часть конвеера

            /* синхронный вызов */
            // await _Next(context); // далее здесь работает оставшаяся часть конвеера

            // Доработка данных в Context.Response
        }
    }
}
