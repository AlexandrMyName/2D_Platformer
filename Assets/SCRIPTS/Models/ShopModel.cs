using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace PlatformerMVC
{
    public class ShopModel 
    {

        public Color _color;
        public ShopView _shopView;
        public ShopModel(ShopView _view) => _shopView = _view;

        public void BuyColor(int colorNumber)
        {
            int score = 0;
            if(colorNumber == 0)
            {
                if (PlayerPrefs.HasKey("Color_red"))
                {
                    PlayerPrefs.SetInt("Current_color", 0);
                   
                                if(Languege.current == "ru")
                       
                                        _shopView._noScore.text = "Успешно!";
                                        else _shopView._noScore.text = "Succes!";


                    _shopView._noScore.color = Color.red;
                }
                else
                {
                    if (PlayerPrefs.HasKey("Win_count"))
                    {
                        score = PlayerPrefs.GetInt("Win_count");

                        if (score >= 45)
                        {
                            PlayerPrefs.SetInt("Color_red", 1);
                            score -= 45;
                            PlayerPrefs.SetInt("Win_count", score);
                            if (Languege.current == "ru")
                                _shopView._noScore.text = "Успешно!";
                            else _shopView._noScore.text = "Success!";
                            _shopView._noScore.color = Color.red;

                            PlayerPrefs.SetInt("Current_color", 0);

                        }
                        else
                        {
                            if (Languege.current == "ru")
                                _shopView._noScore.text = "Похоже, у вас не достаточно опыта!";
                            else _shopView._noScore.text = "Looks, like you don't have enough experience!";
                        }
                    }
                    
                }
            }

            if (colorNumber == 1)
            {
                if (PlayerPrefs.HasKey("Color_green"))
                {

                    PlayerPrefs.SetInt("Current_color", 1);

                    if (Languege.current == "ru")
                        _shopView._noScore.text = "Успешно!";
                    else _shopView._noScore.text = "Success!";
                    _shopView._noScore.color = Color.green;
                }
                else
                {
                    if (PlayerPrefs.HasKey("Win_count"))
                    {
                        score = PlayerPrefs.GetInt("Win_count");

                        if (score >= 45)
                        {
                            PlayerPrefs.SetInt("Color_green", 1);
                            score -= 45;
                            PlayerPrefs.SetInt("Win_count", score);
                            if (Languege.current == "ru")
                                _shopView._noScore.text = "Успешно!";
                            else _shopView._noScore.text = "Success!";
                            _shopView._noScore.color = Color.green;

                            PlayerPrefs.SetInt("Current_color", 1);
                        }
                        else
                        {
                            if (Languege.current == "ru")
                                _shopView._noScore.text = "Похоже, у вас не достаточно опыта!";
                            else _shopView._noScore.text = "Looks, like you don't have enough experience!";
                        }
                    }

                }

            }

            if (colorNumber == 2)
            {
                if (PlayerPrefs.HasKey("Color_blue"))
                {

                    PlayerPrefs.SetInt("Current_color", 2);

                    if (Languege.current == "ru")
                        _shopView._noScore.text = "Успешно!";
                    else _shopView._noScore.text = "Success!";

                    _shopView._noScore.color = Color.blue;
                }
                else
                {
                    if (PlayerPrefs.HasKey("Win_count"))
                    {
                        score = PlayerPrefs.GetInt("Win_count");

                        if (score >= 45)
                        {
                            PlayerPrefs.SetInt("Color_blue", 1);
                            score -= 45;
                            PlayerPrefs.SetInt("Win_count", score);

                            if (Languege.current == "ru")
                                _shopView._noScore.text = "Успешно!";
                            else _shopView._noScore.text = "Success!";
                            _shopView._noScore.color = Color.blue;
                            PlayerPrefs.SetInt("Current_color", 2);
                        }
                        else
                        {
                            if (Languege.current == "ru")
                                _shopView._noScore.text = "Похоже, у вас не достаточно опыта!";
                            else _shopView._noScore.text = "Looks, like you don't have enough experience!";
                        }
                    }

                }
            }
        }
        public void CheckColors()
        {
            if (PlayerPrefs.HasKey("Color_red"))
                HideText(0);
            if (PlayerPrefs.HasKey("Color_green"))
                HideText(1);
            if (PlayerPrefs.HasKey("Color_blue"))
                HideText(2);
            if (PlayerPrefs.HasKey("Win_count")){

              int  score = PlayerPrefs.GetInt("Win_count");
                _shopView._score.text = score.ToString() + " x";
            }
            }
        private void HideText(int color)
        {
            string str = string.Empty;
            if (Languege.current == "ru")
                str = "Приобретено";
            else str = "Purchased";


            if (color == 0)
                _shopView._red.text = str;
            
            else if(color == 1)
            {
                _shopView._green.text = str;
            }
            else if(color == 2)
            {
                _shopView._blue.text = str;
            }

        }
    }
}
