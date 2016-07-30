using System;
using System.Text;

namespace tcc.core.service.Models
{
    public class ExceptionHandler
    {
        public static Response handle(Exception ex)
        {
            StringBuilder error = new StringBuilder();

            error.Append("Error: [" + ex.Message + "]");

            if (ex.InnerException != null && ex.InnerException.InnerException != null)
                error.Append(" - Detail: " + ex.InnerException.InnerException.Message + "]");
            
            return new Response(false, error.ToString(), null, 0);
        }
    }
}
