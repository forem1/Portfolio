﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MicroElectronsManager.Logics
{
    class ApiBuilder
    {
        private static string rootUrl = "http://jedof50245-001-site1.ctempurl.com/api";
        private static RestClient restClient;

        public static RestClient GetInstance()
        {
            if (restClient == null)
            {
                restClient = new RestClient(rootUrl);
            }

            return restClient;
        }
    }
}
