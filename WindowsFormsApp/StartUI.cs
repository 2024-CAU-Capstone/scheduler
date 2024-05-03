﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class StartUI : Form
    {
        private List<Memo> MemoList;
        private List<Schedule> ScheduleList;
        private DateTime date;

        public StartUI()
        {
            InitializeComponent();
            InitStartUI();
        }
        #region public method
        public void AddMemo(Memo memo)
        {
            MemoList.Add(memo);
        }
        public void AddSchedule(Schedule schedule)
        {
            ScheduleList.Add(schedule);
        }
        #endregion

        private void InitStartUI()
        {
            MemoList = new List<Memo>();
            ScheduleList = new List<Schedule>();
            date = DateTime.Now;
            DateselectButton.Text = date.ToString("yy/MM/dd");
            LoadMemoAndSchedule(date);
        }

        private void MakeMomoUI()
        {
            for (int i = 0; i < 2; i++)//test
            {
                Button memoButton = new Button();
                memoButton.Text = "보안 문제 링크";
                memoButton.Location = new Point(370, 120 + i * 50);
                memoButton.Size = new Size(150, 30);
                memoButton.Click += (sender, e) => { MemoListButton_Click(i); };
                this.Controls.Add(memoButton);
            }
            //MemoList에 있는 메모들을 UI에 표시
            for (int i = 0; i < MemoList.Count; i++)
            {

            }
        }
        private void MakeScheduleUI()
        {
            //test
            for (int i = 0; i < 2; i++)
            {
                Label memoLabel = new Label();
                Button memoButton = new Button();
                memoLabel.Text = "07:00";
                memoLabel.Location = new Point(10, 120 + i * 50);
                memoLabel.Size = new Size(50, 15);
                memoButton.Text = "팀 정기 회의";
                memoButton.Location = new Point(10, 135 + i * 50);
                memoButton.Size = new Size(150, 30);
                //memoButton.Click += new EventHandler(ScheduleListButton_Click);
                memoButton.Click += (sender, e) => { ScheduleListButton_Click(i); };
                this.Controls.Add(memoLabel);
                this.Controls.Add(memoButton);
            }
            //ScheduleUI에 있는 메모들을 UI에 표시
            for (int i = 0; i < ScheduleList.Count; i++)
            {

            }
        }
        private void LoadMemoAndSchedule(DateTime date)
        {
            //날짜에 맞는 MemoList와 ScheduleList를 불러옴
            MakeMomoUI();
            MakeScheduleUI();
        }
        #region Button Event
        private void ScheduleListButton_Click(int pos)
        {
            //이미 만들어진 일정 내용 보여주기
            if(ScheduleList.Count < pos)
            {
                MessageBox.Show("해당 일정이 없습니다.");
                return;
            }
            if (ScheduleList[pos] == null)
            {
                ScheduleList[pos].Show();
            }
            else MessageBox.Show("해당 일정이 없습니다.");
        }
        private void MemoListButton_Click(int pos)
        {
            //이미 만들어진 메모 내용 보여주기
            if (MemoList.Count < pos)
            {
                MessageBox.Show("해당 메모가 없습니다.");
                return;
            }
            if (MemoList[pos] == null)
            {
                MemoList[pos].Show();
            }
            else MessageBox.Show("해당 메모가 없습니다.");
        }

        private void MakeMemoButton_Click(object sender, EventArgs e)
        {
            //메모 만들기 창 띄우기
            Memo memo = new Memo(this);
            memo.Show();

        }

        private void MakeScheduleButton_Click(object sender, EventArgs e)
        {
            //일정 만들기 창 띄우기
            Schedule schedule = new Schedule(this);
            schedule.Show();
        }

        private void NextdayButton_Click(object sender, EventArgs e)
        {
            //다음 날짜로 이동
            date = date.AddDays(1);
            DateselectButton.Text = date.ToString("yy/MM/dd");
            LoadMemoAndSchedule(date);
        }

        private void YesterdayButton_Click(object sender, EventArgs e)
        {
            //이전 날짜로 이동
            date = date.AddDays(-1);
            DateselectButton.Text = date.ToString("yy/MM/dd");
            LoadMemoAndSchedule(date);
        }

        private void ExitProgram(object sender, FormClosingEventArgs e)
        {
            SaveMemoAndSchedule();
        }
        #endregion
        private void SaveMemoAndSchedule()
        {
            //MemoList와 ScheduleList를 저장
        }


        
    }
}
