﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone;

namespace Capstone
{
    public class Loader
    {
        //this loads our snacks
        public static string LoadFileLocation = @"C:\Users\Student\Desktop\ProjectsNew\williamsprojectsredo\Vending 2.0\vendingmachine.csv";

        public static SortedDictionary<string, Snack> SnackLoader()
        {
            SortedDictionary<string, Snack> toLoad  = new SortedDictionary<string, Snack>();

            using (StreamReader rdr = new StreamReader(LoadFileLocation))
            {
                while (!rdr.EndOfStream)
                {
                    string[] toSnack = rdr.ReadLine().Split('|');
                    Snack toAdd = new Snack(toSnack);
                    toLoad.Add(toAdd.SlotLocation, toAdd);
                }
            }
            toLoad = Snack.UpdateSoldQuantity(toLoad);

            return toLoad;
        }
    }
}
