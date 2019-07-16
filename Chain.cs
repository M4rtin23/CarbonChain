using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Carbons.Game1;

namespace Carbons{
    public class Chain{
        Carbon[] c;
        private int carbNum, chainLen, type;
        int[] branches;
        public Chain(int chainLen, int[] branches, int type){
            this.chainLen = chainLen;
            this.branches = branches;
            this.type = type;
            for(int i = 1; i<branches.Length; i+=2){
                this.carbNum += branches[i];
            }
            this.carbNum += chainLen;
            c = new Carbon[carbNum];
            for(int i = 0; i < carbNum; i++){
                c[i] = new Carbon();
            }
            for(int i = 0; i < chainLen-1; i++){
                c[i].SetLinks(2, i+1);
                c[i+1].SetLinks(1, i);
            }
            if(branches.Length % 2 != 0){
                if(type == 1){
                    if(c[branches[branches.Length-1]].Links(0) == -1 || c[branches[branches.Length-1]+1].Links(0) == -1){
                        c[branches[branches.Length-1]].SetLinks(0,-2);
                        c[branches[branches.Length-1]+1].SetLinks(0,-3);
                    }else if(c[branches[branches.Length-1]].Links(3) == -1 || c[branches[branches.Length-1]+1].Links(3) == -1){
                        c[branches[branches.Length-1]].SetLinks(3,-2);
                        c[branches[branches.Length-1]+1].SetLinks(3,-3);
                    }
                }else if(type == 2){
                    c[branches[branches.Length-1]].SetLinks(0,-2);
                    c[branches[branches.Length-1]+1].SetLinks(0,-3);
                    c[branches[branches.Length-1]].SetLinks(3,-2);
                    c[branches[branches.Length-1]+1].SetLinks(3,-3);

                }
            }
            Add();
            for(int i = 0; i < c.Length; i++){
                c[i].SetHidrogens();
            }
        }
        public void Draw(SpriteBatch sprBt){
            int x = 0, y = 0;
            for(int i = 0; i < chainLen; i++){
                DrawCarbon(sprBt, i, new Vector2(x, y));
                if(c[i].Links(0) >= 0){
                    int m = c[i].Links(0), p = 0;
                    y--;
                    DrawCarbon(sprBt, m, new Vector2(x, y));
                    while(c[m].Links(0) != -1){
                        p++;
                        y--;
                        DrawCarbon(sprBt, m+1, new Vector2(x, y));
                        m = c[m].Links(0);
                    }
                    y+=p;
                    y++;
                }

                if(c[i].Links(3) >= 0){
                    int m = c[i].Links(3), p = 0;
                    y++;
                    DrawCarbon(sprBt, m, new Vector2(x, y));
                    while(c[m].Links(3) != -1){
                        p++;
                        y++;
                        DrawCarbon(sprBt, m+1, new Vector2(x, y));
                        m = c[m].Links(3);

                    }
                    y-=p;
                    y--;
                }
                x++;
            }
        }
        
        private void Add(){
            int l;
            for(int p = 0; p < branches.Length/2; p++){
                int n = 0;
                for(int i = 1; i < p*2+1; i+=2){
                    n += branches[i];
                }
                if(c[branches[p*2]].Links(0) == -1){
                    l = 0;
                }else if(c[branches[p*2]].Links(3) == -1){
                    l = 3;
                }else{
                    continue;
                }
                c[chainLen+n].SetLinks(3-l, branches[(p*2)]);
                c[branches[p*2]].SetLinks(l, chainLen+n);
                for(int i = chainLen+n; i < chainLen+n+branches[p*2+1]-1; i++){
                    c[i].SetLinks(l , i+1);
                    c[i+1].SetLinks(3-l , i);
                }
            }
        }
        private void DrawCarbon(SpriteBatch sprBt, int c, Vector2 v){
            for(int m = 0; m < carbNum; m++){
                sprBt.DrawString(Font1, ""+m+":", new Vector2(400, 32*m), Color.White);
                for(int n = 0; n < 4; n++){
                    sprBt.DrawString(Font1, ""+this.c[m].Links(n), new Vector2(64*n+500, 32*m), Color.White);
                }
            }

            string CH, N = "";
            switch(this.c[c].GetHidrogens()){
                case 0:
                    CH = " C";
                    break;
                case 1:
                    CH = "CH";
                    break;
                case 2:
                    CH = "CH";
                    N = "2";
                    break;
                case 3:
                    CH = "CH";
                    N = "3";
                    break;
                case 4:
                    CH = "CH";
                    N = "4";
                    break;
                default:
                    CH = "C";
                    break;
            }
            v = v*52 + new Vector2(0, 300);
            sprBt.DrawString(Font1, CH, v, Color.White);
            sprBt.DrawString(Font2, N, v + new Vector2(24, 16), Color.White);
            if(this.c[c].Links(0) >= 0){
                sprBt.DrawString(Font1, " --", v+ new Vector2(10,16), Color.White, 3*(float)Math.PI/2, new Vector2(-4, 16), 1, SpriteEffects.None,0);
            }
            if(this.c[c].Links(0) == -2){
                sprBt.DrawString(Font1, " --", v+ new Vector2(10,18), Color.White, 4*(float)Math.PI/2, new Vector2(-4, 16), 1, SpriteEffects.None,0);
            }
            if(this.c[c].Links(1) >= 0){
                sprBt.DrawString(Font1, " --", v+ new Vector2(10,16), Color.White, 2*(float)Math.PI/2, new Vector2(-4, 16), 1, SpriteEffects.None,0);
            }
            if(this.c[c].Links(3) == -2){
                sprBt.DrawString(Font1, " --", v+ new Vector2(10,8), Color.White, 4*(float)Math.PI/2, new Vector2(-4, 16), 1, SpriteEffects.None,0);
            }
        }
    }
}