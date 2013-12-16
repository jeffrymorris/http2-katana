﻿// Copyright © Microsoft Open Technologies, Inc.
// All Rights Reserved       
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0

// THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT.

// See the Apache 2 License for the specific language governing permissions and limitations under the License.
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Owin.Test.WebApiTest
{
    public class ValuesController : ApiController
    {
        private static Dictionary<int, string> _store = null;

        public ValuesController()
        {
            if (_store == null)
            {
                _store = new Dictionary<int, string>();

                _store.Add(0, "value#0");
                _store.Add(1, "value#1");
            }
        }

        // GET api/values 
        public IEnumerable<string> Get()
        {
            return _store.Values.ToArray();
        }

        // GET api/values/5 
        public string Get(int id)
        {
            if (_store.ContainsKey(id))
            {
                return _store[id];
            }

            return null;
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
            int max;
            if (_store.Keys.Count > 0)
            {
                max = _store.Keys.Max();
            }
            else
            {
                max = 0;
            }

            _store[max + 1] = value;
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
            if (_store.ContainsKey(id))
            {
                _store[id] = value;
            }
            else
            {
                _store.Add(id, value);
            }
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
            if (_store.ContainsKey(id))
            {
                _store.Remove(id);
            }
        }
    }

}