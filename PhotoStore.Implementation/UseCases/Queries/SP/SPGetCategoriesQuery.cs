﻿//using PhotoStore.Application.UseCases.DTO;
//using PhotoStore.Application.UseCases.DTO.Searches;
//using PhotoStore.Application.UseCases.Queries;
//using Dapper;
//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PhotoStore.Implementation.UseCases.Queries.SP
//{
//    public class SPGetCategoriesQuery : IGetCategoriesQuery
//    {
//        public int Id => 2;

//        public string Name => "SP Search Categories";

//        public string Description => "";

//        public IEnumerable<CategoryDto> Execute(BaseSearch search)
//        {
//            var connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=AspVezbe_2;Integrated Security=True");

//            var result = connection.Query<CategoryDto>("SearchCategories", 
//                                           new { search.Keyword }, 
//                                           commandType: CommandType.StoredProcedure);
//            return result;
//        }
//    }
//}
