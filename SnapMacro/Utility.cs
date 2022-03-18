using SnapMacro.JsonModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnapMacro
{
    public static class Utility
    {
        private static Dictionary<char, string[]> dict = new Dictionary<char, string[]>()
        {
            {'a' , new string[]{ "s_a_e dl=0 en=0 cp=0","A" } },
            {'b' , new string[]{ "s_b_e dl=0 en=0 cp=0","B" } },
            {'c' , new string[]{ "s_c_e dl=0 en=0 cp=0","C" } },
            {'d' , new string[]{ "s_d_e dl=0 en=0 cp=0","D" }},
            {'e' , new string[]{ "s_e_e dl=0 en=0 cp=0","E" }},
            {'f' , new string[]{ "s_f_e dl=0 en=0 cp=0","F" } },
            {'g' , new string[]{ "s_g_e dl=0 en=0 cp=0","G" } },
            {'h' , new string[]{ "s_h_e dl=0 en=0 cp=0","H" } },
            {'i' , new string[]{ "s_i_e dl=0 en=0 cp=0","I" } },
            {'j' , new string[]{ "s_j_e dl=0 en=0 cp=0","J" } },
            {'k' , new string[]{ "s_k_e dl=0 en=0 cp=0","K" } },
            {'l' , new string[]{ "s_l_e dl=0 en=0 cp=0","L" } },
            {'m' , new string[]{ "s_m_e dl=0 en=0 cp=0","M" } },
            {'n' , new string[]{ "s_n_e dl=0 en=0 cp=0","N" } },
            {'o' , new string[]{ "s_o_e dl=0 en=0 cp=0","O" } },
            {'p' , new string[]{ "s_p_e dl=0 en=0 cp=0","P" } },
            {'q' , new string[]{ "s_q_e dl=0 en=0 cp=0","Q" } },
            {'r' , new string[]{ "s_r_e dl=0 en=0 cp=0","R" } },
            {'s' , new string[]{ "s_s_e dl=0 en=0 cp=0","S" } },
            {'t' , new string[]{ "s_t_e dl=0 en=0 cp=0","T" } },
            {'u' , new string[]{ "s_u_e dl=0 en=0 cp=0","U" } },
            {'v' , new string[]{ "s_v_e dl=0 en=0 cp=0","V" } },
            {'w' , new string[]{ "s_w_e dl=0 en=0 cp=0","W" } },
            {'x' , new string[]{ "s_x_e dl=0 en=0 cp=0","X" } },
            {'y' , new string[]{ "s_y_e dl=0 en=0 cp=0","Y" } },
            {'z' , new string[]{ "s_z_e dl=0 en=0 cp=0","Z" } },
            {'A' , new string[]{ "s_A_e dl=0 en=0 cp=0","A" } },
            {'B' , new string[]{ "s_B_e dl=0 en=0 cp=0","B" } },
            {'C' , new string[]{ "s_C_e dl=0 en=0 cp=0","C" } },
            {'D' , new string[]{ "s_D_e dl=0 en=0 cp=0","D" }},
            {'E' , new string[]{ "s_E_e dl=0 en=0 cp=0","E" }},
            {'F' , new string[]{ "s_F_e dl=0 en=0 cp=0","F" } },
            {'G' , new string[]{ "s_G_e dl=0 en=0 cp=0","G" } },
            {'H' , new string[]{ "s_H_e dl=0 en=0 cp=0","H" } },
            {'I' , new string[]{ "s_I_e dl=0 en=0 cp=0","I" } },
            {'J' , new string[]{ "s_J_e dl=0 en=0 cp=0","J" } },
            {'K' , new string[]{ "s_K_e dl=0 en=0 cp=0","K" } },
            {'L' , new string[]{ "s_L_e dl=0 en=0 cp=0","L" } },
            {'M' , new string[]{ "s_M_e dl=0 en=0 cp=0","M" } },
            {'N' , new string[]{ "s_N_e dl=0 en=0 cp=0","N" } },
            {'O' , new string[]{ "s_O_e dl=0 en=0 cp=0","O" } },
            {'P' , new string[]{ "s_P_e dl=0 en=0 cp=0","P" } },
            {'Q' , new string[]{ "s_Q_e dl=0 en=0 cp=0","Q" } },
            {'R' , new string[]{ "s_R_e dl=0 en=0 cp=0","R" } },
            {'S' , new string[]{ "s_S_e dl=0 en=0 cp=0","S" } },
            {'T' , new string[]{ "s_T_e dl=0 en=0 cp=0","T" } },
            {'U' , new string[]{ "s_U_e dl=0 en=0 cp=0","U" } },
            {'V' , new string[]{ "s_V_e dl=0 en=0 cp=0","V" } },
            {'W' , new string[]{ "s_W_e dl=0 en=0 cp=0","W" } },
            {'X' , new string[]{ "s_X_e dl=0 en=0 cp=0","X" } },
            {'Y' , new string[]{ "s_Y_e dl=0 en=0 cp=0","Y" } },
            {'Z' , new string[]{ "s_Z_e dl=0 en=0 cp=0","Z" } },
            {'0' , new string[]{ "s_0_e dl=0 en=0 cp=0", "Num0" } },
            {'1' , new string[]{ "s_1_e dl=0 en=0 cp=0", "Num1" } },
            {'2' , new string[]{ "s_2_e dl=0 en=0 cp=0", "Num2" } },
            {'3' , new string[]{ "s_3_e dl=0 en=0 cp=0", "Num3" } },
            {'4' , new string[]{ "s_4_e dl=0 en=0 cp=0", "Num4" } },
            {'5' , new string[]{ "s_5_e dl=0 en=0 cp=0", "Num5" } },
            {'6' , new string[]{ "s_6_e dl=0 en=0 cp=0", "Num6" } },
            {'7' , new string[]{ "s_7_e dl=0 en=0 cp=0", "Num7" } },
            {'8' , new string[]{ "s_8_e dl=0 en=0 cp=0", "Num8" } },
            {'9' , new string[]{ "s_9_e dl=0 en=0 cp=0", "Num9" } },
            {'_' , new string[]{ "s___e dl=0 en=0 cp=0", "OemMinus" } }
        };
        public static Dictionary<String, string> coordinatesDict = new Dictionary<string, string>()
        {
            
            {"StartMultiple" , "11.850000381469727,40.97999954223633" },
            {"AddApp" , "86.25,92.2699966430664" },
            {"AddSnap" , "26.65999984741211,18.260000228881836" },
            {"ClickSnap" , "16.25,83.5999984741211" },
            {"ClickSignUp" , "67.5,94.37000274658203" },
            {"FirstNameClick" , "35,45.65999984741211" },
            {"LastNameClick" , "34.15999984741211,52.220001220703125" },
            {"SignUpAndAccept" , "54.58000183105469,95.55000305175781" },
            {"BirthDateContinue" , "55.83000183105469,71.66000366210938" },
            {"UserNameContinue" , "52.5,95.55000305175781" },
            {"PasswordClick" , "53.75,93.66999816894531" },
            {"EmailClick" , "47.90999984741211,95.08000183105469" },
            {"PhoneSkip" , "93.75,5.849999904632568" },
            {"FriendsSkip" , "93.75,5.849999904632568" },
            {"FriendsSkipConfirm" , "49.58000183105469,62.7599983215332" },
            {"ContacsSkip" , "51.25,68.13999938964844" },
            {"SearchField" , "48.349998474121094,11.850000381469727" },
            {"AddFriend" , "83.55000305175781,5.369999885559082" },
            {"Add" , "87.16999816894531,23.329999923706055" },
            {"Return" , "8.220000267028809,5.550000190734863" },
            {"Profile" , "6.25,4.619999885559082" },
            {"Settings" , "93.75,5.550000190734863" },
            {"LogoutDragtStart" , "46.04999923706055,75.37000274658203" },
            {"LogoutDragtEnd" , "42.43000030517578,64.80999755859375" },
            {"Logout" , "11.84000015258789,91.4800033569336" },
            {"DontSaveLogin" , "50.40999984741211,62.060001373291016" },
            {"ConfirmLogout" , "50.31999969482422,61.849998474121094" },
            {"ConfirmLogout2" , "50,50.369998931884766" },
            {"CloseSnap" , "90.41000366210938,89.69000244140625" },
            {"ClickMultiple" , "65,45.43000030517578" }

        };
        private static string[] Names = new string[] {"sameer" , "fadi", "alim" ,"raja", "sohaib" ,"kamil"} ;
        public static List<Event> getWord(string word , ref int timestamp)
        {
            List<Event> events = new List<Event>();
            var arr = word.ToCharArray();
            foreach(var letter in arr)
            {
                var letArr = dict[letter];
                events.Add(new Event
                {
                    EventType = "KeyDown",
                    KeyName = letArr[1],
                    Timestamp = timestamp +5
                });
                timestamp += 5;
                events.Add(new Event
                {
                    EventType = "IME",
                    Msg = letArr[0],
                    Timestamp = timestamp
                });
                events.Add(new Event
                {
                    EventType = "KeyUp",
                    KeyName = letArr[1],
                    Timestamp = timestamp + 5
                });

                timestamp += 100;
            }

            return events;
        }

        public static List<Event> changePassLoc(ref int timestamp)
        {
            var events = new List<Event>();

            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseDown",
                Timestamp = timestamp+5,
                X = 29.600000381469727,
                Y = 52.220001220703125
            });
            timestamp += 5;
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseUp",
                Timestamp = timestamp+5,
                X = 29.600000381469727,
                Y = 52.220001220703125
            });
            timestamp += 100;
            return events;
        }

        public static List<Event> LoginBtnClick(ref int timestamp)
        {
            var events = new List<Event>();

            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseDown",
                Timestamp = timestamp + 5,
                X = 58.220001220703125,
                Y = 97.4000015258789
            });
            timestamp += 5;
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseUp",
                Timestamp = timestamp + 5,
                X = 58.220001220703125,
                Y = 97.4000015258789
            });
            timestamp += 50;
            return events;
        }
        public static List<Event> SearchFieldFocus(ref int timestamp)
        {
            var events = new List<Event>();
            timestamp += 10;
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseDown",
                Timestamp = timestamp + 5,
                X = 48.349998474121094,
                Y = 11.850000381469727
            });
            timestamp += 5;
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseUp",
                Timestamp = timestamp + 5,
                X = 48.349998474121094,
                Y = 11.850000381469727
            });
            timestamp += 50;
            return events;
        }

        public static List<Event> Click(ref int timestamp,string coordinates)
        {
            var arr = coordinates.Split(',');
            var x = double.Parse(arr[0]);
            var y = double.Parse(arr[1]);
            var events = new List<Event>();
            timestamp += 10;
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseDown",
                Timestamp = timestamp + 5,
                X = x,
                Y = y
            });
            timestamp += 5;
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseUp",
                Timestamp = timestamp + 5,
                X = x,
                Y = y
            });
            timestamp += 50;
            return events;
        }

        public static List<Event> KeyStrike(ref int timestamp, string KeyName)
        {
            var events = new List<Event>();
            timestamp += 10;
            events.Add(new Event
            {
                
                EventType = "KeyDown",
                KeyName = KeyName,
                Timestamp = timestamp + 5

            });
            timestamp += 5;
            events.Add(new Event
            {

                EventType = "KeyUp",
                KeyName = KeyName,
                Timestamp = timestamp + 5

            });
            timestamp += 50;
            return events;
        }
        public static List<Event> SelectAll(ref int timestamp)
        {
            var events = new List<Event>();
            timestamp += 10;
            events.Add(new Event
            {
                EventType = "KeyDown",
                KeyName = "Ctrl",
                Timestamp = timestamp
            });
            timestamp += 5;
            events.Add(new Event
            {
                EventType = "KeyDown",
                KeyName = "A",
                Timestamp = timestamp
            });
            timestamp += 5;
            events.Add(new Event
            {
                EventType = "KeyUp",
                KeyName = "A",
                Timestamp = timestamp
            });
            timestamp += 5;
            events.Add(new Event
            {
                EventType = "KeyUp",
                KeyName = "Ctrl",
                Timestamp = timestamp
            });
            timestamp += 5;
            timestamp += 50;
            return events;
        }

        public static List<Event> Drag(ref int timestamp, string startCoordinates , string endCoordinates)
        {
            var startArr = startCoordinates.Split(',');
            var endArr = endCoordinates.Split(',');
            var sx = double.Parse(startArr[0]); var sy = double.Parse(startArr[1]);
            var ex = double.Parse(endArr[0]);  var ey = double.Parse(endArr[1]);
            var events = new List<Event>();
            timestamp += 15;
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseDown",
                Timestamp = timestamp + 5,
                X = sx,
                Y = sy
            });
            timestamp += 10;
            while(sy > ey)
            {
                sy -= .5;

                
                events.Add(new Event
                {
                    Delta = 0,
                    EventType = "MouseMove",
                    Timestamp = timestamp,
                    X = sx,
                    Y = sy
                });
                timestamp += 10;
            }
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp,
                X = ex,
                Y = ey
            });
            timestamp += 1;
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseUp",
                Timestamp = timestamp,
                X = ex,
                Y = ey
            });
            timestamp += 50;
            return events;
        }

        public static List<Event> DragHard(ref int timestamp)
        {
            var events = new List<Event>();
            timestamp += 15;
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseDown",
                Timestamp = timestamp + 5,
                X = 68.75,
                Y = 92.2699966430664
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 55,
                X = 68.75,
                Y = 91.33000183105469
            });

            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp+7,
                X = 68.75,
                Y = 89.69000244140625
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 8,
                X = 68.75,
                Y = 87.3499984741211
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 8,
                X = 68.75,
                Y = 84.30000305175781
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 9,
                X = 68.75,
                Y = 80.08999633789062
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 7,
                X = 68.75,
                Y = 74.94000244140625
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 8,
                X = 68.75,
                Y = 66.73999786376953
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 8,
                X = 68.75,
                Y = 55.2599983215332
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 8,
                X = 68.75,
                Y = 39.56999969482422
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 9,
                X = 68.75,
                Y = 25.520000457763672
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 7,
                X = 68.75,
                Y = 11.699999809265137
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 8,
                X = 68.75,
                Y = -0.4699999988079071
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 8,
                X = 66.66000366210938,
                Y = -8.899999618530273
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 8,
                X = 65.83000183105469,
                Y = -16.8700008392334
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseMove",
                Timestamp = timestamp + 9,
                X = 63.33000183105469,
                Y = -24.360000610351562
            });
            events.Add(new Event
            {
                Delta = 0,
                EventType = "MouseUp",
                Timestamp = timestamp,
                X = 63.33000183105469,
                Y = -24.360000610351562
            });
            timestamp += 50;
            return events;
        }

        public static List<Event> GetEmail(ref int timestamp, string word)
        {
            var events = new List<Event>();
            timestamp += 10;
            events.AddRange(getWord(word,ref timestamp));
            timestamp += 100;
            events.Add(new Event
            {

                EventType = "KeyDown",
                KeyName = "Shift",
                Timestamp = timestamp + 5

            });
            timestamp += 5;
            events.Add(new Event
            {

                EventType = "KeyDown",
                KeyName = "2",
                Timestamp = timestamp + 5

            });
            timestamp += 5;
            events.Add(new Event
            {

                EventType = "IME",
                Msg = "s_@_e dl=0 en=0 cp=0",
                Timestamp = timestamp + 5

            });
            timestamp += 5;
            events.Add(new Event
            {

                EventType = "KeyUp",
                KeyName = "Shift",
                Timestamp = timestamp + 5

            });
            timestamp += 5;
            events.Add(new Event
            {

                EventType = "KeyUp",
                KeyName = "2",
                Timestamp = timestamp + 5

            });
            timestamp += 100;
            events.AddRange(getWord("gmail", ref timestamp));
            timestamp += 100;
            events.Add(new Event
            {

                EventType = "KeyDown",
                KeyName = "OemPeriod",
                Timestamp = timestamp + 5

            });
            timestamp += 5;
            events.Add(new Event
            {

                EventType = "IME",
                Msg = "s_._e dl=0 en=0 cp=0",
                Timestamp = timestamp + 5

            });
            timestamp += 5;
            events.Add(new Event
            {

                EventType = "KeyUp",
                KeyName = "OemPeriod",
                Timestamp = timestamp + 5

            });
            timestamp += 100;
            events.AddRange(getWord("com", ref timestamp));
            timestamp += 50;
            return events;
        }

        public static List<Event> Minimize(ref int timestamp)
        {
            var events = new List<Event>();
            timestamp += 10;
            events.Add(new Event
            {

                EventType = "UiRecentApps",
                Timestamp = timestamp + 5

            });
            timestamp += 50;
            return events;
        }


        public static RegisterModel Produce(int AccountsNum , string Path)
        {
            //string path = @"JsonFiles\SubscribeModelIntitialEvents.json";
            //var friends = File.ReadAllLines(@"Temp\Friends.txt");
            var friends = File.ReadAllLines(Path);
            //var AccountsNum = 11;
            var timestamp = 1500;
            var model = new RegisterModel();
            var events = Click(ref timestamp, coordinatesDict["StartMultiple"]);
            model.Events.AddRange(events);
            timestamp += 5000;
            /*for(int i = 0; i < 4; i++)
            {
                events = Click(ref timestamp, coordinatesDict["AddApp"]);
                model.Events.AddRange(events);
                timestamp += 2000;
                events = Click(ref timestamp, coordinatesDict["AddSnap"]);
                model.Events.AddRange(events);
                timestamp += 5000;
            }*/
            int appRounds = AccountsNum % 3 == 0 ? AccountsNum / 3 : AccountsNum / 3 + 1;
            Random r = new Random();
            for(int i = 0; i < appRounds; i++)
            {
                events = Click(ref timestamp, coordinatesDict["AddApp"]);
                model.Events.AddRange(events);
                timestamp += 1000;
                events = Click(ref timestamp, coordinatesDict["AddSnap"]);
                model.Events.AddRange(events);
                timestamp += 8000;
                events = Click(ref timestamp, coordinatesDict["ClickSnap"]);
                model.Events.AddRange(events);
                timestamp += 15000;
                for(int j = 0; j < 3; j++)
                {
                    events = Click(ref timestamp, coordinatesDict["ClickSignUp"]);
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    events = Click(ref timestamp, coordinatesDict["FirstNameClick"]);
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    var firstname = Names[r.Next(0, Names.Length - 1)];
                    events = getWord(firstname, ref timestamp);
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    events = Click(ref timestamp, coordinatesDict["LastNameClick"]);
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    var lastname = Names[r.Next(0, Names.Length - 1)];
                    events = getWord(lastname, ref timestamp);
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    events = Click(ref timestamp, coordinatesDict["SignUpAndAccept"]);
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    events = KeyStrike(ref timestamp,"Up");
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    events = Click(ref timestamp, coordinatesDict["BirthDateContinue"]);
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    events = Click(ref timestamp, coordinatesDict["UserNameContinue"]);
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    events = getWord(firstname+ timestamp, ref timestamp);
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    events = Click(ref timestamp, coordinatesDict["PasswordClick"]);
                    model.Events.AddRange(events);
                    timestamp += 30000;
                    events = GetEmail(ref timestamp,firstname + lastname + timestamp);
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    events = Click(ref timestamp, coordinatesDict["EmailClick"]);
                    model.Events.AddRange(events);
                    timestamp += 4000;
                    events = Click(ref timestamp, coordinatesDict["PhoneSkip"]);
                    model.Events.AddRange(events);
                    timestamp += 5000;
                    events = Click(ref timestamp, coordinatesDict["PhoneSkip"]);
                    model.Events.AddRange(events);
                    /*timestamp += 5000;
                    events = Click(ref timestamp, coordinatesDict["PhoneSkip"]);
                    model.Events.AddRange(events);*/
                    timestamp += 5000;
                    events = Click(ref timestamp, coordinatesDict["FriendsSkipConfirm"]);
                    model.Events.AddRange(events);
                    timestamp += 10000;
                    events = Click(ref timestamp, coordinatesDict["ContacsSkip"]);
                    model.Events.AddRange(events);
                    timestamp += 5000;
                    events = Click(ref timestamp, coordinatesDict["AddFriend"]);
                    model.Events.AddRange(events);
                    timestamp += 5000;
                    foreach (var friend in friends)
                    {
                        timestamp += 2000;
                        events = Click(ref timestamp, coordinatesDict["SearchField"]);
                        model.Events.AddRange(events);
                        timestamp += 2000;
                        events = SelectAll(ref timestamp);
                        model.Events.AddRange(events);
                        timestamp += 2000;
                        events = getWord(friend, ref timestamp);
                        model.Events.AddRange(events);
                        timestamp += 5000;
                        events = Click(ref timestamp, coordinatesDict["Add"]);
                        model.Events.AddRange(events);
                        timestamp += 3000;
                    }
                    model.Events.AddRange(Click(ref timestamp, coordinatesDict["Return"]));
                    timestamp += 4000;
                    model.Events.AddRange(Click(ref timestamp, coordinatesDict["Profile"]));
                    timestamp += 10000;
                    model.Events.AddRange(Click(ref timestamp, coordinatesDict["Settings"]));
                    timestamp += 3000;
                    /*for (int k = 0; k < 23; k++)
                    {
                        model.Events.AddRange(Drag(ref timestamp, coordinatesDict["LogoutDragtStart"],
                        coordinatesDict["LogoutDragtEnd"]));
                        timestamp += 5;
                    }*/
                    model.Events.AddRange(DragHard(ref timestamp));
                    timestamp += 3000;
                    model.Events.AddRange(Click(ref timestamp, coordinatesDict["Logout"]));
                    timestamp += 3000;
                    model.Events.AddRange(Click(ref timestamp, coordinatesDict["DontSaveLogin"]));
                    timestamp += 3000;
                    model.Events.AddRange(Click(ref timestamp, coordinatesDict["ConfirmLogout"]));
                    timestamp += 3000;
                    model.Events.AddRange(Click(ref timestamp, coordinatesDict["ConfirmLogout2"]));
                    timestamp += 10000;

                }
                model.Events.AddRange(Minimize(ref timestamp));
                timestamp += 3000;
                model.Events.AddRange(Click(ref timestamp, coordinatesDict["CloseSnap"]));
                timestamp += 3000;
                model.Events.AddRange(Click(ref timestamp, coordinatesDict["ClickMultiple"]));
                timestamp += 10000;

            }

            return model;
        }
    }
}
