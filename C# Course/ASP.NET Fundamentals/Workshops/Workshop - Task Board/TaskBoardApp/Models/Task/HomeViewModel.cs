﻿using System;
namespace TaskBoardApp.Models.Task
{
	public class HomeViewModel
	{
		public int AllTasksCount { get; set; }
		public List<HomeBoardModel> BoardsWithTasksCount { get; set; } = null!;
		public int UserTasksCount { get; set; }
	}
}

