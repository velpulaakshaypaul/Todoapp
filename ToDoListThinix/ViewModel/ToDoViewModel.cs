using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using ToDoListThinix.Model;
using System.Windows;
using System.Xml;


namespace ToDoListThinix.ViewModel
{
    public class ToDoViewModel
    {
        private ObservableCollection<ToDoModel> _ToDo;
        public ObservableCollection<ToDoModel> ToDo { get { return _ToDo; } }
        private string _details;
        private string _titles;
        private string _updateddetails;
        private string _updatedtitles;
        private string _IndexToDelete;
        public string details { get { return _details; } set { _details = value; } }
        public string titles { get { return _titles; } set { _titles = value; } }
        public string updateddetails { get { return _updateddetails; } set { _updateddetails = value; } }
        public string updatedtitles { get { return _updatedtitles; } set { _updatedtitles = value; } }
        public string IndexToDelete { get { return _IndexToDelete; } set { _IndexToDelete = value; } }
        public ToDoViewModel()
        {
            _ToDo = new ObservableCollection<ToDoModel>();           
        }
        public void add_to_list()
        {
            if ((String.IsNullOrEmpty(titles)) && (String.IsNullOrEmpty(details)))
            {
                MessageBox.Show("Failed to add item");
            }
            else
            {
                _ToDo.Add(new ToDoModel() { Title = titles, Details = details });
                MessageBox.Show("Successfully Added Item");
            }

        }
        public string ConvertStringToNumbers()
        {
            string numbers=string.Empty;
            for (int i = 0; i < IndexToDelete.Length; i++)
            {
                if (Char.IsDigit(IndexToDelete[i]))
                    numbers += IndexToDelete[i];
            }
            return numbers;
        }
        public void delete_element()
        {
           // ToDoModel currentmodel=new ToDoModel();
            if ((String.IsNullOrEmpty(IndexToDelete)))
            {
                MessageBox.Show("For multiple Deletion,Please Enter Indexes to delete with spaces between them");
                
                //_ToDo.Remove(_ToDo.Selec )
            }
            else
            {
                int j;
                string deletedlist = ConvertStringToNumbers();
                try
                {
                    for (int i = 0; i < deletedlist.Length; i++)
                    {
                        j = (int)Char.GetNumericValue(deletedlist[i]);
                        _ToDo[j-1].Title="00000delte" ;
                    }
                    for(int i=0;i<_ToDo.Count;i++)
                    {
                        if(_ToDo[i].Title=="00000delte" )
                        {
                            _ToDo.RemoveAt(i);
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("Please Enter Indexes to delete with spaces between them");
                }
            }
        }
        public void updatenode(ToDoModel updatenode)
        {
            int index=_ToDo.IndexOf(updatenode);
            ToDoModel dummy=new ToDoModel();
            dummy.Title=updatedtitles;
            dummy.Details=updateddetails;
           /* var item = _ToDo.FirstOrDefault(i => i.Title == updatenode.Title);
            if (item != null)
            {
                item.Title = updatedtitles;
                MessageBox.Show(Convert.ToString(item.Title));
                item.Details = updateddetails;
            }*/
            _ToDo.Remove(updatenode);
            _ToDo.Insert(index, dummy);
        }
        public void delete(ToDoModel itemtodelete)
        {
            _ToDo.Remove(itemtodelete);
        }
        public void checkboxchecked(ToDoModel TitleText)
        {

        }
        public void checkboxunchecked(ToDoModel itemtodelete)
        { }
        public void SaveContent()
        {
            ToDoModel savecurrentmodel = new ToDoModel();
            using (XmlTextWriter writer = new XmlTextWriter("ThinixProgrammingChallenge.xml", System.Text.Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("MyToDoList");
                writer.WriteElementString("NumberofItems", Convert.ToString(_ToDo.Count));
                for (int i = 0; i < _ToDo.Count; i++)
                {

                    savecurrentmodel = _ToDo[i];
                    writer.WriteElementString("Title", savecurrentmodel.Title);
                    writer.WriteElementString("Details", savecurrentmodel.Details);
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

        }
        public void loadContent()
        {
            int count=0;
            ToDoModel loadcurrentmodel = new ToDoModel();
            _ToDo.Clear();
            try
            {
                using (XmlReader reader = XmlReader.Create("ThinixProgrammingChallenge.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            //return only when you have START tag

                            switch (reader.Name.ToString())
                            {
                                case "Title":
                                    //MessageBox.Show(reader.ReadString());
                                    loadcurrentmodel.Title = reader.ReadString();
                                    break;

                                case "Details":
                                    //MessageBox.Show(reader.ReadString());
                                    loadcurrentmodel.Details = reader.ReadString();
                                    _ToDo.Add(loadcurrentmodel);
                                    count += 1;
                                    break;
                            }
                        }
                        Console.WriteLine("");
                    }
                }
            }
            catch 
            {
                MessageBox.Show("File Not Found");
            }
        }
    }
}
