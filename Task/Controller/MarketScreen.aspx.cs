﻿using BELayer;
using DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BALayer;
using System.Timers;

namespace Task
{
    public partial class Market : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //System.Timers.Timer aTimer = new System.Timers.Timer();
            //aTimer.Elapsed += new ElapsedEventHandler(Page_Load);
            //aTimer.Interval = 1000;
            //aTimer.Enabled = true;
            if (!IsPostBack)
            {
                //Random rand = new Random();
                //List<Int32> Price = new List<Int32>();
                //for (Int32 i = 0; i < 101; i++)
                //{
                //    Int32 curValue = rand.Next(1, 100);
                //    while (Price.Exists(value => value == curValue))
                //    {
                //        curValue = rand.Next(1, 100);
                //    }
                //    Price.Add(curValue);
                //}

                List<Stock> stockes = StockBAL.GetAll();
                grd_view.Visible = true;
                //grd_view2.Visible = true;
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();

                for (int i = 0; i < stockes.Capacity; i++)
                {
                    DataRow toInsert = dt.NewRow();
                    DataRow toInsert2 = dt.NewRow();
                    dt.Rows.InsertAt(toInsert, i);
                    dt.Rows.InsertAt(toInsert2, i);

                    //dt.Rows[i]["Price"] = Price;
                    //dt.Rows[i]["test"] = stockes[i].ToString();

                }
                
                grd_view2.DataSource = stockes;
                grd_view.DataSource = stockes;
                grd_view.DataBind();
                grd_view2.DataBind();

                Response.AppendHeader("Refresh", "10");
                

            }



        }


        protected void GridView1_SelectedIndexChanged2(object sender, EventArgs e)
        {
            
        }
    }
}