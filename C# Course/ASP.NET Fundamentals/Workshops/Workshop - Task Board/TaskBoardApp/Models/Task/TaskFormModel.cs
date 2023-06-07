using System;
using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data.Constants;

namespace TaskBoardApp.Models.Task
{
	public class TaskFormModel
	{
		[Required]
		[StringLength(DataConstants.Task.TaskMaxTitle,
			MinimumLength = DataConstants.Task.TaskMinTitle,
			ErrorMessage = "Title should be at least {2} characters long.")]
		public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Task.TaskMaxDescription,
			MinimumLength = DataConstants.Task.TaskMinDescription,
        ErrorMessage = "Description should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

		[Display(Name = "Board")]
		public int BoardId { get; set; }
		
		public IEnumerable<TaskBoardModel> ?Boards { get; set; }
	}
}

