﻿using Dapper.TQuery.Development;
using MyDapper.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace TQuerykjkj
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ForumUser> forums = new List<ForumUser>();
            forums.AsQueryable().Where(x => x.IsDelete);
            IDbConnection con = new SqlConnection("Server=hgws27.win.hostgator.com; Database=quickpps_test; User ID=quickpps_test;Password=Hj4d6~4q; Trusted_Connection=False; MultipleActiveResultSets=True");
            
            var hfg = con.TQuery<ForumUser>().Where(x => x.IsDelete == true).Where(x => x.Role > 5).SqlString;
            var g = con.CreateAllTablesIfNotExists();//.Execute();
            var kjj = con.GetAllDbTablesType();
            List<ForumUser> forumUsers = new List<ForumUser>();
            for (var i = 0; i < 6; i++)
            {
                forumUsers.Add(new ForumUser { Role = i * 59 });
            }
            con.TQuery<ForumUser>().InsertList(forumUsers);
            var doublejoin = con.TQuery<ForumUser>().Where(x => x.Role > 5).Any();//.SqlString;//.Join(con.TQuery<Question>(), x => x.Id, x => x.UserId, (u,q) => q)
                //.Join(con.TQuery<Answer>(), x => x.Id, x => x.QuestionId, (questions, answers) => new { questions, answers })
                //.Join(con.TQuery<Comment>(), x => x.answers.Id, x => x.AnswerId, (answers, comments) => new { answers.questions.Body, comments, Downvotes = answers.answers.Downvotes, comments.Upvotes })
                //.Where(x=>x.Upvotes > 5 && x.Body !=null)
                //.Update(x=> new ForumUser { Role = 66, Status = 5 + x.Status })
                //.Bottom(5)
                //.SqlString;
            Console.WriteLine(doublejoin);
            //var h = con.TQuery<ForumUser>().CreateTable().SqlString;  //.Join(con.TQuery<Question>(), x => x.Id, x => x.UserId, (Users, Questions) => new { Users, Questions }).Where(x => x.Users.Role == 1);
            //var tempList = new List<ForumUser>();
            //var ilk = con.GetAllDbTablesType();
        }

    }

}




