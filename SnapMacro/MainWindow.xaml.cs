using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using SnapMacro.JsonModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnapMacro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            int accounts;
            if (!int.TryParse(AccText.Text, out accounts) || FileLabel.Content.ToString() == "No File!")
            {
                MessageBox.Show("أدخل كل المطلوبات بصورة صحيحة رجاء!");
                return;
            }

            try
            {
                var model = Utility.Produce(accounts, FileLabel.Content.ToString());

                //string fileName = @"C:\Users\hp\Desktop\SubscribeMacro.json";
                //string fileName = @"Temp\SubscribeMacro.json";
                string jsonString2 = JsonConvert.SerializeObject(model, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Json File(*.json)|*.json";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string fileName = saveFileDialog.FileName;
                    File.WriteAllText(fileName, jsonString2);
                    MessageBox.Show("تم تصدير الملف");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            /*var ookiiDialog = new VistaFolderBrowserDialog();
            if (ookiiDialog.ShowDialog() == true)
            {
                // do something with the folder path
                MessageBox.Show(ookiiDialog.SelectedPath);
            }*/
            //string path = "C:\\Users\\hp\\Desktop\\Macro.json";
            /*string path = @"JsonFiles\SubscribeModelIntitialEvents.json";

            using (StreamReader r = new StreamReader(path))
            {
                string jsonString = r.ReadToEnd();
                //Event initialEvens = JsonConvert.DeserializeObject<Event>(jsonString);
                //var model = new SubscribeModel();
                
                var model = JsonConvert.DeserializeObject<SubscribeModel>(jsonString);
                var timestamp = 22537;
                var logins = File.ReadAllLines(@"Temp\Logins.txt")[0];
                var logArr = logins.Split(',');
                var userEvs = Utility.getWord(logArr[0], ref timestamp);
                model.Events.AddRange(userEvs);
                var changePassLocEvs = Utility.changePassLoc(ref timestamp);
                model.Events.AddRange(changePassLocEvs);
                var passEvs = Utility.getWord(logArr[1], ref timestamp);
                model.Events.AddRange(passEvs);
                var loginBtnClickEvs = Utility.LoginBtnClick(ref timestamp);
                model.Events.AddRange(loginBtnClickEvs);
                timestamp += 8000;
                var AddNewFriendEvs = Utility.Click(ref timestamp, Utility.coordinatesDict["AddFriend"]);
                model.Events.AddRange(AddNewFriendEvs);
                timestamp += 2000;
                var friends= File.ReadAllLines(@"Temp\Friends.txt");
                foreach(var friend in friends)
                {
                    timestamp += 2000;
                    var searchFieldClicl = Utility.Click(ref timestamp, Utility.coordinatesDict["SearchField"]);
                    model.Events.AddRange(searchFieldClicl);
                    timestamp += 2000;
                    model.Events.AddRange(Utility.SelectAll(ref timestamp));
                    timestamp += 2000;
                    model.Events.AddRange(Utility.getWord(friend, ref timestamp));
                    timestamp += 2000;
                    model.Events.AddRange(Utility.Click(ref timestamp, Utility.coordinatesDict["Add"]));
                    timestamp += 2000;
                }

                model.Events.AddRange(Utility.Click(ref timestamp, Utility.coordinatesDict["Return"]));
                timestamp += 2000;
                model.Events.AddRange(Utility.Click(ref timestamp, Utility.coordinatesDict["Profile"]));
                timestamp += 2000;
                model.Events.AddRange(Utility.Click(ref timestamp, Utility.coordinatesDict["Settings"]));
                timestamp += 2000;
                for(int i  = 0 ; i < 23; i++){
                    model.Events.AddRange(Utility.Drag(ref timestamp, Utility.coordinatesDict["LogoutDragtStart"],
                    Utility.coordinatesDict["LogoutDragtEnd"]));
                    timestamp += 5;
                }                
                timestamp += 2000;
                model.Events.AddRange(Utility.Click(ref timestamp, Utility.coordinatesDict["Logout"]));
                timestamp += 2000;
                model.Events.AddRange(Utility.Click(ref timestamp, Utility.coordinatesDict["ConfirmLogout"]));
                timestamp += 2000;
                model.Events.AddRange(Utility.Click(ref timestamp, Utility.coordinatesDict["ConfirmLogout2"]));
                
                var model = Utility.Produce(11,FileLabel.Content.ToString());

                //string fileName = @"C:\Users\hp\Desktop\SubscribeMacro.json";
                string fileName = @"Temp\SubscribeMacro.json";
                string jsonString2 = JsonConvert.SerializeObject(model, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                File.WriteAllText(fileName, jsonString2);           
            }*/
        }

        private void ChooserBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                FileLabel.Content = openFileDialog.FileName;
        }
    }
}
