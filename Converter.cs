﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Carbons{
    public class Converter{
        public static string ToExtended(string chain){
            //Search stuff like "2,2 Di Metil" and converts it to something like "2-Metil-2-Metil".
            int start = chain.IndexOf(",")-1;
            int dividor = chain.IndexOf("-", start);
            int end = chain.IndexOf("-" ,dividor + 1);
            int length = end - start;
            //Where the branch first character is.
            int branch = chain.IndexOf(" ", start, length);
            string branchType = chain.Substring(branch+1,end-branch-1);
            string newChainName = "";
            //Sets the whole modified chain name to newChainName.
            for(int x = 0; x < countComas(chain.Substring(start,length))*2+2; x+=2){
                if(newChainName == ""){
                    newChainName = chain.Substring(start,length).Substring(x,1)+"-"+branchType;
                }else{
                    newChainName = newChainName+"-"+chain.Substring(start,length).Substring(x,1)+"-"+branchType;
                }
            }
            return chain.Replace(chain.Substring(start,length), newChainName);
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
        public static int[] BranchesToMachine(string chain){
            string[] newBranchesName;

            while(chain.Contains(",")){
                chain = ToExtended(chain);
            }
            newBranchesName = chain.ToLower().Split("-");
            string[] temporary = new string[newBranchesName.Length-1];
            for(int i = 0; i < temporary.Length;i++){
                temporary[i] = newBranchesName[i];
            }
            newBranchesName = temporary;
            for(int i = 0; i < newBranchesName.Length; i++){
                switch(newBranchesName[i]){
                    case "metil":
                        newBranchesName[i] = "2";
                        break;
                    case "etil":
                        newBranchesName[i] = "3";
                        break;
                    case "propil":
                        newBranchesName[i] = "4";
                        break;
                    case "butil":
                        newBranchesName[i] = "5";
                        break;
                    case "pentil":
                        newBranchesName[i] = "6";
                        break;
                    case "hexil":
                        newBranchesName[i] = "7";
                        break;
                    case "heptil":
                        newBranchesName[i] = "8";
                        break;
                    case "octil":
                        newBranchesName[i] = "9";
                        break;
                    case "nontil":
                        newBranchesName[i] = "10";
                        break;
                    case "decil":
                        newBranchesName[i] = "11";
                        break;
                }
            }
            int[] result = new int[newBranchesName.Length];
            for(int i = 0; i < newBranchesName.Length; i++){
                result[i] = System.Convert.ToInt32(newBranchesName[i])-1;
            }
            return (result);
        }
        public static int ChainToMachine(string chain){
            string chainName = chain.ToLower().Split("-")[chain.Split("-").Length-1];
            switch(chainName){
                    case "metano":
                        chainName = "1";
                        break;
                    case "etano":
                        chainName = "2";
                        break;
                    case "propano":
                        chainName = "3";
                        break;
                    case "butano":
                        chainName = "4";
                        break;
                    case "pentano":
                        chainName = "5";
                        break;
                    case "hexano":
                        chainName = "6";
                        break;
                    case "heptano":
                        chainName = "7";
                        break;
                    case "octano":
                        chainName = "8";
                        break;
                    case "nontano":
                        chainName = "9";
                        break;
                    case "decano":
                        chainName = "10";
                        break;
                }
            return (Convert.ToInt32(chainName));
        }
    }
}