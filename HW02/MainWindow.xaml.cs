using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Mvc.CustomThreadPool;

namespace Mvc
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<string> _messagesCollection = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            Thread threadViewRandomValue = new Thread(ViewMessages);
            threadViewRandomValue.Start();
        }

        private void ViewMessages()
        {
            const int taskQuantity = 10;
            const int maxDegreeOfParallelism = 5;
            
            var threadPool = new CustomThreadPool.CustomThreadPool(5);
            var random = new Random();
            var tasks = new KeyValuePair<Priority, ITask>[taskQuantity];
            for (var i = 0; i < tasks.Length; i++)
            {
                var priority = (Priority)random.Next(0, 3);
                tasks[i] = new KeyValuePair<Priority, ITask>(priority, new CustomTask(i));

                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    _messagesCollection.Add($"Created task {i+1} with priority {priority}");
                    ListMessages.ItemsSource = _messagesCollection;
                }));
                Thread.Sleep(1000);
            }

            Parallel.ForEach(tasks, new ParallelOptions { MaxDegreeOfParallelism = maxDegreeOfParallelism },
                task => { threadPool.Execute(task.Value, task.Key); });

            threadPool.Stop();
        }
    }
}

