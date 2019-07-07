using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Carbons{
    public class Carbon{
        int[] links = new int[4];
        int hidrogens;
        public Carbon(){
            for(int i = 0; i<4;  i++){
                links[i] = -1;
            }
        }
        public int Links(int n){
            return links[n];
        }
        public void SetLinks(int l, int v){
            links[l] = v;
        }
        public void SetHidrogens(){
            for(int i = 0; i < 4; i++){
                if(links[i] == -1){
                    hidrogens++;
                }
            }
        }
        public int GetHidrogens(){
            return hidrogens;
        }
    }
}