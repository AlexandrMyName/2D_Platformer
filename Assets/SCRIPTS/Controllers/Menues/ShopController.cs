using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class ShopController
    {
        private ShopView _shopView;
         
        private ShopModel _shopModel;

        public ShopController(ShopView shopView){
            _shopView = shopView;
            _shopModel = new ShopModel(_shopView);   
        }


        public void BuyColor(int rgb){
            _shopModel.CheckColors();
            _shopModel.BuyColor(rgb);
        }
        public void BuyGun(int gunNumber) { /*##*/ }

        public void ShowShop(){
            _shopView._backPanel.SetActive(false);
            _shopView._colorsPanel.SetActive(false);
            _shopView?._gunsPanel.SetActive(false);
            _shopView._panel.SetActive(true);
        }
        public void ShowGuns(){
            _shopView._backPanel.SetActive(false);
            _shopView._panel.SetActive(false);
            _shopView._colorsPanel.SetActive(false);
            _shopView?._gunsPanel.SetActive(true);
        }
        public void ShowColors(){
            _shopModel.CheckColors();
            _shopView._backPanel.SetActive(false);
            _shopView._panel.SetActive(false);
            _shopView._colorsPanel.SetActive(true);
            _shopView?._gunsPanel.SetActive(false);
        }
    }
}