﻿using System.Collections.Generic;
using RestApiFromSqlSchema.Components.Schema;

namespace RestApiFromSqlSchema.Components.Templates.WebApi
{
    public class ListApiActionTemplate
    {
        public string Route { get; set; }
        public string RouteName { get; set; }
        public IList<Column> OrderByColumns { get; set; }
    }
}