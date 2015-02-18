using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task5Graphic
{
    static class Program
    {
         static AppDomain GraphicDrawer;        //будет хранить объект домена приложения TextDrawer
        static AppDomain TableData;    //будет хранить домена приложения TextWindow
        static Assembly GraphicAsm;      //будет хранить объект сборки TextDrawer.exe
        static Assembly TableAsm;  //будет хранить объект сборки TextWindow.exe
        static Form GraphicWindow;       //будет хранить объект окна TextDrawer
        static Form TableWindow;       //будет хранить объект окна TextWindow
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GraphicDrawer = AppDomain.CreateDomain("GraphicDrawer");
            TableData = AppDomain.CreateDomain("TableData");
            GraphicAsm = GraphicDrawer.Load(AssemblyName.GetAssemblyName("GraphicDrawer.exe"));
            TableAsm = TableData.Load(AssemblyName.GetAssemblyName("TableData.exe"));
            GraphicWindow = Activator.CreateInstance(GraphicAsm.GetType("GraphicDrawer.Form1")) as Form;
            TableWindow = Activator.CreateInstance(TableAsm.GetType("TableData.Form1"),
                new object[]
                {
                    GraphicAsm.GetModule("GraphicDrawer.exe"),
                    GraphicWindow
                }) as Form;
            (new Thread(new ThreadStart(RunTable))).Start();
            (new Thread(new ThreadStart(RunGraphic))).Start();
        }
        static void RunGraphic()
        {
            GraphicWindow.ShowDialog();
            AppDomain.Unload(GraphicDrawer);
        }

        static void RunTable()
        {
            TableWindow.ShowDialog();
            Application.Exit();
        }
    }
}
