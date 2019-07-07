﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Carbons{
    public class Converts{
        public static string Con(string c){
            int i = c.IndexOf(",")-1;
            int m = c.IndexOf("-", i);
            int f = c.IndexOf("-" ,m+1);
            int s = c.IndexOf(" ", i, f);
            string h = "", a = c.Substring(s+1,f-s-1);
            for(int x = 0; x < countComas(c.Substring(i,f-i))*2+2; x+=2){
                if(h == ""){
                    h = c.Substring(i,f-i).Substring(x,1)+"-"+a;
                }else{
                    h = h+"-"+c.Substring(i,f-i).Substring(x,1)+"-"+a;
                }
            }
            return c.Replace(c.Substring(i,f-i), h);
        }
        private static int countComas(string s){
            int i = 0;
            for(int o = 0; o < s.Length; o++){
                if(s.Substring(o,1) == ","){
                    i++;
                }
            }
            return i;
        }
        public static (int[], int) Added(string s){
            string[] p, t;
            string j;
            s = Con(s);
            p = s.ToLower().Split("-");
            t = new string[p.Length-1];
            j = p[p.Length-1];
            for(int i = 0; i < t.Length;i++){
                t[i] = p[i];
            }
            p = t;
            for(int i = 0; i < p.Length; i++){
                switch(p[i]){
                    case "metil":
                        p[i] = "2";
                        break;
                    case "etil":
                        p[i] = "3";
                        break;
                    case "propil":
                        p[i] = "4";
                        break;
                    case "butil":
                        p[i] = "5";
                        break;
                    case "pentil":
                        p[i] = "6";
                        break;
                    case "hexil":
                        p[i] = "7";
                        break;
                    case "heptil":
                        p[i] = "8";
                        break;
                    case "octil":
                        p[i] = "9";
                        break;
                    case "nontil":
                        p[i] = "10";
                        break;
                    case "decil":
                        p[i] = "11";
                        break;
                }
            }
            int[] r = new int[p.Length];
            for(int i = 0; i < p.Length; i++){
                r[i] = System.Convert.ToInt32(p[i])-1;
            }
            switch(j){
                    case "metano":
                        j = "1";
                        break;
                    case "etano":
                        j = "2";
                        break;
                    case "propano":
                        j = "3";
                        break;
                    case "butano":
                        j = "4";
                        break;
                    case "pentano":
                        j = "5";
                        break;
                    case "hexano":
                        j = "6";
                        break;
                    case "heptano":
                        j = "7";
                        break;
                    case "octano":
                        j = "8";
                        break;
                    case "nontano":
                        j = "9";
                        break;
                    case "decano":
                        j = "10";
                        break;
                }
            return (r,Convert.ToInt32(j));
        }
    }
}