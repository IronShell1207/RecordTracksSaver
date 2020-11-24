using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyData
{
    class SpotifyPages
    {
        public static readonly string MainPageUrl = "https://open.spotify.com";
        public static readonly string SearchPageUrl = "https://open.spotify.com/search";
    }
    public class SpotifyPatches
    {
        public static By loginPageButton = By.XPath("//button[@data-testid='login-button']");
        #region login page
        public static By LoginField = By.Id("login-username");
        public static By PassField = By.Id("login-password");
        public static By LogInButt = By.Id("login-button"); 
        #endregion
        public static By ErrorPage = By.ClassName("ErrorPage");
        public static By Playlists = By.XPath("//ul/div"); // поиск всех плейлистов. Взять плейлист через свойство href //a[@href='/playlist/#id плейлста#']
        #region создание плейлиста
        public static By NewPlstBtn = By.XPath("//button[@type='button'])[2]"); //кнопка добавления плейлиста (не надежная)
        public static By NewPlstDefName = By.XPath("(//h1[@as='h1'])[2]"); // и прямо по нему правой кнопкой для меню
        public static By NewPlstEditD = By.XPath("//div[@id='context-menu-root']/ul[1]/li[4]/button[1]"); // edit details btn in context menu
        public static By NewPlstFieldName = By.XPath("//input[@data-testid='playlist-edit-details-name-input']");
        public static By NewPlstSaveName = By.XPath("//button[@data-testid='playlist-edit-details-save-button']");
        #endregion
        #region поиск 
        public static By SearchBtn = By.XPath("//a[@href='/search']");
        public static By SeatchField = By.XPath("//input[@data-testid='search-input']");
        public static By SongsLikeOnly = By.XPath("//div[@data-testid='tracklist-row'][1]//button[@title='Save to Your Library']"); // сохранить песню в лайканые песни
        public static By SongMenu = By.XPath("//div[@data-testid='tracklist-row'][1]"); // нажать по нему правой кнопкой
        public static By AddToPlBtn = By.XPath("(//div[@id='context-menu-root'])/ul[1]/li[6]/button[1]/span[1]");
        public static string PlaylstsList = "//body/div[@id='tippy-1']/div[@id='context-menu-root']/ul[1]/li[6]/div[1]/ul[1]/li"; // список плейлистов +[{0}] для выбора нужного
        // чтобы искать по имени надо просто перебрать весь список до первого вхождения нужного наименования плейлиста))
        // string а не By для того чтобы не создавать две переменные, а просто добавить к этой поле для выбора при необходимости
        #endregion
    }
}
