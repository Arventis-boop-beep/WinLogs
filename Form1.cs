﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WInLogsViewer
{
    public partial class Form1 : Form
    {
        public EventLog[] eventLogs;
        public EventLogEntryCollection entries;
        int currentJournal;

        public Form1()
        {
            InitializeComponent();
            Date.Width = table.Width / 4;
            Type.Width = table.Width / 4;
            Creator.Width = table.Width / 4;
            Category.Width = table.Width / 4;

            Log.Width = 3 * (explorer.Width / 4);
            Amount.Width = (explorer.Width / 4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            eventLogs = EventLog.GetEventLogs();

            foreach (EventLog log in eventLogs)
            {
                var row = new ListViewItem(new[] { log.Log.ToString(), log.Entries.Count.ToString() });
                explorer.Items.Add(row);
            }
        }

        private void filterLog(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                EventLogEntry[] sorted = new EventLogEntry[entries.Count];
                table.Items.Clear();
                entries.CopyTo(sorted, 0);
                Quicksort(sorted, 0, sorted.Length - 1);

                for (int i = 0; i < sorted.Length; i++)
                {
                    var row = new ListViewItem(new[] {sorted[i].TimeWritten.ToString(),
                                                      sorted[i].EntryType.ToString(),
                                                      sorted[i].Source,
                                                      sorted[i].Category});
                    table.Items.Add(row);
                }

            }
            else if (e.Column == 1)
            {
                table.Items.Clear();

                string[] types = {"Trace", "Debug", "Information", "Warning", "Error", "Critical", "None" };
                
                foreach(string type in types)
                {
                    foreach(EventLogEntry str in entries)
                    {
                        if(str.EntryType.ToString() == type)
                        {
                            var row = new ListViewItem(new[] {str.TimeWritten.ToString(),
                                                      str.EntryType.ToString(),
                                                      str.Source,
                                                      str.Category});
                            table.Items.Add(row);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

            }
            else
            {
                return;
            }
        }

        private void chooseLog(object sender, MouseEventArgs e)
        {
            table.Items.Clear();
            for (int i = 0; i < explorer.Items.Count; i++)
            {
                var rectangle = explorer.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    entries = eventLogs[i].Entries;
                    currentJournal = i;
                    for (int j = 0; j < entries.Count; j++)
                    {
                        var row = new ListViewItem(new[] {entries[j].TimeWritten.ToString(),
                                                          entries[j].EntryType.ToString(),
                                                          entries[j].Source,
                                                          entries[j].Category});
                        table.Items.Add(row);
                    }
                    return;
                }
            }
        }

        private void showMessage(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < table.Items.Count; i++)
            {
                var rectangle = table.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    msgTextBox.Text = entries[i].Message.ToString();
                    return;
                }
            }
        }

        int Partition(EventLogEntry[] array, int start, int end)
        {
            int marker = start; // divides left and right subarrays
            for (int i = start; i < end; i++)
            {
                if (DateTime.Compare(array[i].TimeWritten, array[end].TimeWritten) >= 0) // array[end] is pivot
                {
                    (array[marker], array[i]) = (array[i], array[marker]);
                    marker++;
                }
            }
            // put pivot(array[end]) between left and right subarrays
            (array[marker], array[end]) = (array[end], array[marker]);
            return marker;
        }

        void Quicksort(EventLogEntry[] array, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = Partition(array, start, end);
            Quicksort(array, start, pivot - 1);
            Quicksort(array, pivot + 1, end);
        }

        static EventLogEntry[] BubbleSort(EventLogEntry[] mas)
        {
            EventLogEntry temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (DateTime.Compare(mas[i].TimeWritten, mas[j].TimeWritten) > 0)
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
    }

}
