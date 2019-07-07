using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Carbons.Game1;

namespace Carbons{
    public class Chain{
        Carbon[] c;
        private int carbNum, chainLen;
        int[] added;
        public Chain(int chainLen, int[] added){
            this.chainLen = chainLen;
            this.added = added;
            for(int i = 1; i<added.Length; i+=2){
                this.carbNum += added[i];
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
            Add();
            for(int i = 0; i < c.Length; i++){
                c[i].SetHidrogens();
            }
        }
        public void Draw(SpriteBatch sprBt){
            sprBt.DrawString(Font1, ""+carbNum, new Vector2(0, 0), Color.White);
            for(int m = 0; m < carbNum; m++){
                sprBt.DrawString(Font1, ""+m+":", new Vector2(400, 32*m), Color.White);
                for(int n = 0; n < 4; n++){
                    sprBt.DrawString(Font1, ""+c[m].Links(n), new Vector2(64*n+500, 32*m), Color.White);
                }
            }
            int x = 0, y = 0;
            for(int i = 0; i < chainLen; i++){
                DrawCarbon(sprBt, i, new Vector2(x, y));
                if(c[i].Links(0) != -1){
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

                if(c[i].Links(3) != -1){
                    int m = c[i].Links(3), p = 0;
                    y++;
                    //sprBt.DrawString(Font1, "C", new Vector2(x*32, y*32+250), Color.White);
                    DrawCarbon(sprBt, m, new Vector2(x, y));
                    while(c[m].Links(3) != -1){
                        p++;
                        y++;
                        //sprBt.DrawString(Font1, "C", new Vector2(x*32, y*32+250), Color.White);
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
            for(int p = 0; p < added.Length/2; p++){
                int n = 0;
                for(int i = 1; i < p*2+1; i+=2){
                    n += added[i];
                }
                if(c[added[p*2]].Links(0) == -1){
                    l = 0;
                }else{
                    l = 3;
                }
                c[chainLen+n].SetLinks(3-l, added[(p*2)]);
                c[added[p*2]].SetLinks(l, chainLen+n);
                for(int i = chainLen+n; i < chainLen+n+added[p*2+1]-1; i++){
                    c[i].SetLinks(l , i+1);
                    c[i+1].SetLinks(3-l , i);
                }
            }
        }
        float i;
        private void DrawCarbon(SpriteBatch sprBt, int c, Vector2 v){
            i+=1/240f;
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
            if(this.c[c].Links(0) != -1){
                sprBt.DrawString(Font1, " --", v+ new Vector2(10,16), Color.White, 3*(float)Math.PI/2/*rotation */, new Vector2(-4, 16), 1, SpriteEffects.None,0);
            }
            if(this.c[c].Links(1) != -1){
                sprBt.DrawString(Font1, " --", v+ new Vector2(10,16), Color.White, 2*(float)Math.PI/2/*rotation */, new Vector2(-4, 16), 1, SpriteEffects.None,0);
            }            
        }
    }
}