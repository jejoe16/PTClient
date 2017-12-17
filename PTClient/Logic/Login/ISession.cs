using System;

namespace PTClient.Logic.Login
{
    interface ISession
    {
        /// <summary>
        /// returns the username of the user with the current session
        /// </summary>
        /// <returns></returns>
        String GetUserName();
        /// <summary>
        /// returns the password of the current user
        /// </summary>
        /// <returns></returns>
        String GetPassword();
        /// <summary>
        /// removes the current user from the session
        /// </summary>
        void ClearSession();
        /// <summary>
        /// sets the captain status of the current user
        /// </summary>
        /// <param name="capt"></param>
        bool GetCaptain();
        /// <summary>
        /// checks if anyone is logged in
        /// </summary>
        /// <returns></returns>
        bool LoggedIn();
        /// <summary>
        /// sets the users position
        /// </summary>
        /// <param name="position"></param>
        void SetUserPosition(String position);
        /// <summary>
        /// creates a new user in the session
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Captain"></param>
        void createUser(string Username, string Password, bool Captain);


    }
}
