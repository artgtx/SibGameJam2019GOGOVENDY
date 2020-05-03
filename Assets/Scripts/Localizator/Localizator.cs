using UnityEngine;
using System;
using System.Collections.Generic;

public class Localizator
{

    public static Language activeLanguage;
    private static Dictionary<Language, Dictionary<string, string>> _localizedTexts = new Dictionary<Language, Dictionary<string, string>>(){
        { Language.RUSSIAN, new Dictionary<string, string>()
            {
             {"start","старт" },
             {"load","загрузить" },
             {"dial1","Привет" },  
             {"dial2","я тестовый диалог" },  
             {"dial3","халявно написанный" },  
             {"dial4","пока!" }, 
             {"fishDialog","Товарищи! консультация с широким активом позволяет выполнять важные задания по разработке систем массового участия. Не следует, однако забывать, что сложившаяся структура организации позволяет выполнять важные задания по разработке форм развития. " },  	

             {"key","text" },  
            }
        },
        { Language.ENGLISH, new Dictionary<string, string>()
            {
             {"test","test" },  	
             
            
            }
        }
    };


    private static Dictionary<Language, Dictionary<string, Sprite>> _localizedSprites = new Dictionary<Language, Dictionary<string, Sprite>>(){
        {Language.RUSSIAN, new Dictionary<string, Sprite>()
            {
             
               
            }
        },
        {Language.ENGLISH, new Dictionary<string, Sprite>()
            {
                
                
            }
        }
       
    };

    public static string GetTextValue(string key)
    {
        
/*
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Russian:
                Localizator.activeLanguage = Language.RUSSIAN;
                break;
            case SystemLanguage.English:
                Localizator.activeLanguage = Language.ENGLISH;
                break;
            
            default:
                Localizator.activeLanguage = Language.ENGLISH;
                break;
        }

   */ 

        Localizator.activeLanguage = Language.RUSSIAN;
        
        
        string _res = "";
        try
        {
            _res = _localizedTexts[activeLanguage][key];
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace.ToString());
        }

        return _res.ToUpper();
    }

    public static string GetTextValueForLanguage(string key, Language language)
    {
        string _res = "";
        try
        {
            _res = _localizedTexts[language][key];
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace.ToString());
        }
        return _res;
    }
    public static Sprite GetSpriteValue(string key)
    {
        try
        {
            return _localizedSprites[activeLanguage][key];
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace.ToString());
            return null;
        }
    }
}

public enum Language
{
    ENGLISH = 0,
    RUSSIAN = 1,
    
}
