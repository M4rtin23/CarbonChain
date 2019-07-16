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
            string[] temporary;
            //if(chain.Length % 2 == 1){
                temporary = new string[newBranchesName.Length-1];
            /*}else{
                temporary = new string[newBranchesName.Length-2];
            }*/
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
                if(chainName.Contains("met")){
                    chainName = "1";
                }else if(chainName.Contains("et")){
                    chainName = "2";
                }else if(chainName.Contains("prop")){
                    chainName = "3";
                }else if(chainName.Contains("but")){
                    chainName = "4";
                }else if(chainName.Contains("pent")){
                    chainName = "5";
                }else if(chainName.Contains("hex")){
                    chainName = "6";
                }else if(chainName.Contains("hept")){
                    chainName = "7";
                }else if(chainName.Contains("oct")){
                    chainName = "8";
                }else if(chainName.Contains("non")){
                    chainName = "9";
                }else if(chainName.Contains("dec")){
                    chainName = "10";
                }
            return (Convert.ToInt32(chainName));
        }
        public static int TypeOfChain(string chain){
            int number = ChainToMachine(chain);
            string chainName = chain.ToLower().Split("-")[chain.Split("-").Length-1];
            string prefix = "";
            switch(number){
                case 1:
                    prefix = "met";
                    break;
                case 2:
                    prefix = "et";
                    break;
                case 3:
                    prefix = "prop";
                    break;
                case 4:
                    prefix = "but";
                    break;
                case 5:
                    prefix = "pent";
                    break;
                case 6:
                    prefix = "hex";
                    break;
                case 7:
                    prefix = "hept";
                    break;
                case 8:
                    prefix = "oct";
                    break;
                case 9:
                    prefix = "non";
                    break;
                case 10:
                    prefix = "dec";
                    break;
            }
            switch(chainName.Replace(prefix, "")){
                default:
                case "ano":
                    return 0;
                case "eno":
                    return 1;
                case "ino":
                    return 2;
            }
        }
        public static int SpecialNumber(string chain){
            return Convert.ToUInt16(chain.Split("-")[chain.Split("-").Length-2]);
        }
    }
}