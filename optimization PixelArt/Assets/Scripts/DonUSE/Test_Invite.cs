//using Facebook.Unity;
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class Test_Invite : MonoBehaviour
//{
//    public TextMeshPro FriendsText;

//    private void Awake()
//    {
//        if (!FB.IsInitialized)
//        {
//            FB.Init(() =>
//            {
//                if (FB.IsInitialized)
//                    FB.ActivateApp();
//                else
//                    Debug.LogError("Couldn't initialize");
//            },
//            isGameShown =>
//            {
//                if (!isGameShown)
//                    Time.timeScale = 0;
//                else
//                    Time.timeScale = 1;
//            });
//        }
//        else
//            FB.ActivateApp();
//    }

//    #region Login / Logout
//    public void FacebookLogin()
//    {
//        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
//        FB.LogInWithReadPermissions(permissions);
//    }

//    public void FacebookLogout()
//    {
//        FB.LogOut();
//    }
//    #endregion

//    public void FacebookShare()
//    {
//        FB.ShareLink(new System.Uri("https://resocoder.com"), "Check it out!",
//            "Good programming tutorials lol!",
//            new System.Uri("https://resocoder.com/wp-content/uploads/2017/01/logoRound512.png"));
//    }

//    #region Inviting
//    public void FacebookInvite()
//    {

//    }
//    #endregion

//    public void GetFriendsPlayingThisGame()
//    {
//        string query = "/me/friends";
//        FB.API(query, HttpMethod.GET, result =>
//        {
//            var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
//            var friendsList = (List<object>)dictionary["data"];
//            FriendsText.text = string.Empty;
//            foreach (var dict in friendsList)
//                FriendsText.text += ((Dictionary<string, object>)dict)["name"];
//        });
//    }
//    public void GetOnlyFriendsPlayingThisGame()
//    {
//        string query = "/me/friends";
//        FB.API(query, HttpMethod.GET, result =>
//        {
//            var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
//            var friendsList = (List<object>)dictionary["data"];
//            FriendsText.text = string.Empty;
//            foreach (var dict in friendsList)
//                FriendsText.text += ((Dictionary<string, object>)dict)["name"];
//        });
//    }
//    public void GetFriendsPlayingThisGame2()
//    {
//        //string query = WWW.EscapeURL("SELECT uid, name, is_app_user, pic_square FROM user WHERE uid IN (SELECT uid2 FROM friend WHERE uid1 = me()) AND is_app_user = 1");
//        //string queryfql = "/fql?q=" + query;

//        string queryfql = "/fql?q=SELECT uid, name, is_app_user, pic_square FROM user WHERE uid IN " +
//                    "(SELECT uid2 FROM friend WHERE uid1 = me()) AND is_app_user = 1";

//        FB.API(queryfql, HttpMethod.GET, result =>
//        {
//            var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
//            var friendsList = (List<object>)dictionary["data"];
//            FriendsText.text = string.Empty;
//            foreach (var dict in friendsList)
//            {
//                FriendsText.text += ((Dictionary<string, object>)dict)["name"];
//            }
//        });

//    }
//}
