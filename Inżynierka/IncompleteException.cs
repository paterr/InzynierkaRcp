using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inzynierka
{
    public class IncompleteException:Exception
    {
        public IncompleteException() : base() { }
        public IncompleteException(string msg):base(msg) { }

        //System.SystemException
            //System.Runtime.InteropServices.ExternalException
                //System.Data.Common.DbException
                    //MySql.Data.MySqlClient.MySqlException
                        //MySql.Data.MySqlClient.MySqlException
    }
}
