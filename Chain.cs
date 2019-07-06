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
            for(int i = 0; i < chainLen; i++){
                c[i].SetLinks(2, i+1);
                if(i+1 < chainLen){
                    c[i+1].SetLinks(1, i);
                }
            }
            // int q = 0;
            // for(int i = 1; i < added.Length; i+=2){
            //     q += added[i];
            // }
            
            // for(int i = 0; i < added.Length/2; i++){
            //     SetAdded(i);
            // }
            // c[5].SetLinks(0, 6);
            // c[6].SetLinks(0, 7);
            Add();
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
                sprBt.DrawString(Font1, "C", new Vector2(x*32, y*32+250), Color.White);                
                if(c[i].Links(0) != -1){
                    y--;
                    sprBt.DrawString(Font1, "C", new Vector2(x*32, y*32+250), Color.White);
                    if(c[c[i].Links(0)].Links(0) != -1){
                        y--;
                        sprBt.DrawString(Font1, "C", new Vector2(x*32, y*32+250), Color.White);
                        y++;
                    } 
                    y++;
                }
                // if(c[i].Links(1) != -1){
                //     x--;
                // }
                if(c[i].Links(3) != -1){
                    y++;
                    sprBt.DrawString(Font1, "C", new Vector2(x*32, y*32+250), Color.White);
                    y--;
                }
                x++;
            }
        }
        private void SetAdded(int p){
            int n = 0;
            for(int i = 1; i + (added.Length-p*2) < added.Length; i+=2){
                n += added[i];
            }
            //chain number added[p-1], secondchainLen added[p]
        }
        private void Add(){
            for(int p = 0; p < added.Length/2; p++){
                int n = 0;
                for(int i = 1; i < p*2+1; i+=2){
                    n += added[i];
                }
                c[chainLen+n].SetLinks(3, added[(p*2)]);
                c[added[p*2]].SetLinks(0, chainLen+n);
                for(int i = chainLen+n; i < chainLen+n+added[p*2+1]-1; i++){
                    c[i].SetLinks(0, i+1);
                    c[i+1].SetLinks(3, i);
                }
            }
        }
        int P(int i){
            if(i < 0){
                return 0;
            }else{
                return i;
            }
        }
    }
}