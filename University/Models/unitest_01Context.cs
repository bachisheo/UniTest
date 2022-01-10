using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class unitest_01Context : DbContext
    {
        public unitest_01Context()
        {
        }

        public unitest_01Context(DbContextOptions<unitest_01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AnswerToTask> AnswerToTask { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Discipline> Discipline { get; set; }
        public virtual DbSet<EntryInStudyPlan> EntryInStudyPlan { get; set; }
        public virtual DbSet<EntryInStudyStatement> EntryInStudyStatement { get; set; }
        public virtual DbSet<Gradebook> Gradebook { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Speciality> Speciality { get; set; }
        public virtual DbSet<StatementHeader> StatementHeader { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudyGroup> StudyGroup { get; set; }
        public virtual DbSet<StudyPlan> StudyPlan { get; set; }
        public virtual DbSet<StudyStatementHeader> StudyStatementHeader { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskInTest> TaskInTest { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=34.140.136.71;Database=unitest_01;Username=postgres;Password=0489;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminPk);

                entity.ToTable("admin");

                entity.HasIndex(e => e.AdminPk)
                    .HasName("ключ пдминистратора")
                    .IsUnique();

                entity.HasIndex(e => e.Login)
                    .HasName("Логин")
                    .IsUnique();

                entity.Property(e => e.AdminPk).HasColumnName("admin_pk");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Patronimyc).HasColumnName("patronimyc");
            });

            modelBuilder.Entity<AnswerToTask>(entity =>
            {
                entity.HasKey(e => new { e.AnswerPk, e.ResultPk, e.TaskInTestPk, e.TicketPk });

                entity.ToTable("answer_to_task");

                entity.HasIndex(e => e.AnswerPk)
                    .HasName("Ключ ответа")
                    .IsUnique();

                entity.Property(e => e.AnswerPk)
                    .HasColumnName("answer_pk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ResultPk).HasColumnName("result_pk");

                entity.Property(e => e.TaskInTestPk).HasColumnName("task_in_test_pk");

                entity.Property(e => e.TicketPk).HasColumnName("ticket_pk");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnName("answer");

                entity.HasOne(d => d.ResultPkNavigation)
                    .WithMany(p => p.AnswerToTask)
                    .HasForeignKey(d => d.ResultPk)
                    .HasConstraintName("result_for_answer");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.AnswerToTask)
                    .HasForeignKey(d => new { d.TaskInTestPk, d.TicketPk })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("task_for_answer");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentPk);

                entity.ToTable("department");

                entity.HasIndex(e => e.DepartmentPk)
                    .HasName("Ключ кафедры")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("Наименование")
                    .IsUnique();

                entity.Property(e => e.DepartmentPk).HasColumnName("department_pk");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.HasKey(e => e.DisciplinePk);

                entity.ToTable("discipline");

                entity.HasIndex(e => e.DisciplinePk)
                    .HasName("Ключ дисциплины")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("name_uniq")
                    .IsUnique();

                entity.Property(e => e.DisciplinePk).HasColumnName("discipline_pk");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<EntryInStudyPlan>(entity =>
            {
                entity.HasKey(e => new { e.EntryInStudyPlanPk, e.StudyPlanPk, e.SpecialityPk });

                entity.ToTable("entry_in_study_plan");

                entity.HasIndex(e => e.DisciplinePk)
                    .HasName("IX_discipline_of_entry");

                entity.HasIndex(e => e.EntryInStudyPlanPk)
                    .HasName("Ключ записи в учебном плане")
                    .IsUnique();

                entity.Property(e => e.EntryInStudyPlanPk)
                    .HasColumnName("entry_in_study_plan_pk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StudyPlanPk).HasColumnName("study_plan_pk");

                entity.Property(e => e.SpecialityPk).HasColumnName("speciality_pk");

                entity.Property(e => e.DisciplinePk).HasColumnName("discipline_pk");

                entity.HasOne(d => d.DisciplinePkNavigation)
                    .WithMany(p => p.EntryInStudyPlan)
                    .HasForeignKey(d => d.DisciplinePk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("discipline_of_entry");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.EntryInStudyPlan)
                    .HasForeignKey(d => new { d.StudyPlanPk, d.SpecialityPk })
                    .HasConstraintName("entry_in_plane");
            });

            modelBuilder.Entity<EntryInStudyStatement>(entity =>
            {
                entity.HasKey(e => new { e.EntryInStudyStatementPk, e.StudyStatementHeaderPk });

                entity.ToTable("entry_in_study_statement");

                entity.HasIndex(e => e.DisciplinePk)
                    .HasName("IX_discipline_for_statement_entry");

                entity.HasIndex(e => e.EntryInStudyStatementPk)
                    .HasName("Ключ записи в учебном поручении")
                    .IsUnique();

                entity.HasIndex(e => e.GroupPk)
                    .HasName("IX_group_for_entry");

                entity.Property(e => e.EntryInStudyStatementPk)
                    .HasColumnName("entry_in_study_statement_pk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StudyStatementHeaderPk).HasColumnName("study_statement_header_pk");

                entity.Property(e => e.DisciplinePk).HasColumnName("discipline_pk");

                entity.Property(e => e.GroupPk).HasColumnName("group_pk");

                entity.HasOne(d => d.DisciplinePkNavigation)
                    .WithMany(p => p.EntryInStudyStatement)
                    .HasForeignKey(d => d.DisciplinePk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("discipline_for_statement_entry");

                entity.HasOne(d => d.GroupPkNavigation)
                    .WithMany(p => p.EntryInStudyStatement)
                    .HasForeignKey(d => d.GroupPk)
                    .HasConstraintName("group_for_entry");

                entity.HasOne(d => d.StudyStatementHeaderPkNavigation)
                    .WithMany(p => p.EntryInStudyStatement)
                    .HasForeignKey(d => d.StudyStatementHeaderPk)
                    .HasConstraintName("study_statement_header_for_entry");
            });

            modelBuilder.Entity<Gradebook>(entity =>
            {
                entity.HasKey(e => new { e.GradebookPk, e.StudentPk });

                entity.ToTable("gradebook");

                entity.HasIndex(e => e.GradebookPk)
                    .HasName("gradebook_key")
                    .IsUnique();

                entity.HasIndex(e => e.GroupPk)
                    .HasName("IX_group_for_gradebook");

                entity.HasIndex(e => e.Number)
                    .HasName("gradebook_number_key")
                    .IsUnique();

                entity.Property(e => e.GradebookPk)
                    .HasColumnName("gradebook_pk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StudentPk).HasColumnName("student_pk");

                entity.Property(e => e.GroupPk).HasColumnName("group_pk");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number");

                entity.HasOne(d => d.GroupPkNavigation)
                    .WithMany(p => p.Gradebook)
                    .HasForeignKey(d => d.GroupPk)
                    .HasConstraintName("group_for_gradebook");

                entity.HasOne(d => d.StudentPkNavigation)
                    .WithMany(p => p.Gradebook)
                    .HasForeignKey(d => d.StudentPk)
                    .HasConstraintName("student_for_gradebook");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.ResultPk);

                entity.ToTable("result");

                entity.HasIndex(e => e.ResultPk)
                    .HasName("result_key")
                    .IsUnique();

                entity.HasIndex(e => e.StatementHeaderPk)
                    .HasName("IX_header_for_result");

                entity.HasIndex(e => e.TicketPk)
                    .HasName("IX_ticket_for_result");

                entity.HasIndex(e => new { e.GradebookPk, e.StudentPk })
                    .HasName("IX_gradebook_for_result");

                entity.Property(e => e.ResultPk).HasColumnName("result_pk");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.GradebookPk).HasColumnName("gradebook_pk");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.StatementHeaderPk).HasColumnName("statement_header_pk");

                entity.Property(e => e.StudentPk).HasColumnName("student_pk");

                entity.Property(e => e.TicketPk).HasColumnName("ticket_pk");

                entity.HasOne(d => d.StatementHeaderPkNavigation)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.StatementHeaderPk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("header_for_result");

                entity.HasOne(d => d.TicketPkNavigation)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.TicketPk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ticket_for_result");

                entity.HasOne(d => d.Gradebook)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => new { d.GradebookPk, d.StudentPk })
                    .HasConstraintName("gradebook_for_result");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.HasKey(e => e.SpecialityPk);

                entity.ToTable("speciality");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.HasIndex(e => e.SpecialityPk)
                    .HasName("spec_key")
                    .IsUnique();

                entity.Property(e => e.SpecialityPk).HasColumnName("speciality_pk");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<StatementHeader>(entity =>
            {
                entity.HasKey(e => e.StatementHeaderPk);

                entity.ToTable("statement_header");

                entity.HasIndex(e => e.Number)
                    .HasName("Номер ведомости")
                    .IsUnique();

                entity.HasIndex(e => e.StatementHeaderPk)
                    .HasName("Ключ шапки ведомости")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntryInStudyStatementPk, e.StudyStatementHeaderPk })
                    .HasName("IX_statement_header_for_entry");

                entity.Property(e => e.StatementHeaderPk).HasColumnName("statement_header_pk");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.EntryInStudyStatementPk).HasColumnName("entry_in_study_statement_pk");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number");

                entity.Property(e => e.StudyStatementHeaderPk).HasColumnName("study_statement_header_pk");

                entity.HasOne(d => d.EntryInStudyStatement)
                    .WithMany(p => p.StatementHeader)
                    .HasForeignKey(d => new { d.EntryInStudyStatementPk, d.StudyStatementHeaderPk })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("statement_header_for_entry");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentPk);

                entity.ToTable("student");

                entity.HasIndex(e => e.Login)
                    .HasName("student_login_key")
                    .IsUnique();

                entity.HasIndex(e => e.StudentPk)
                    .HasName("student_key")
                    .IsUnique();

                entity.Property(e => e.StudentPk).HasColumnName("student_pk");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            });

            modelBuilder.Entity<StudyGroup>(entity =>
            {
                entity.HasKey(e => e.GroupPk)
                    .HasName("Unique_Identifier1");

                entity.ToTable("study_group");

                entity.HasIndex(e => e.GroupPk)
                    .HasName("group_key")
                    .IsUnique();

                entity.HasIndex(e => e.Number)
                    .HasName("group_number_uniq")
                    .IsUnique();

                entity.HasIndex(e => new { e.StudyPlanPk, e.SpecialityPk })
                    .HasName("IX_plan_for_group");

                entity.Property(e => e.GroupPk).HasColumnName("group_pk");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number");

                entity.Property(e => e.SpecialityPk).HasColumnName("speciality_pk");

                entity.Property(e => e.StudyPlanPk).HasColumnName("study_plan_pk");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.StudyGroup)
                    .HasForeignKey(d => new { d.StudyPlanPk, d.SpecialityPk })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plan_for_group");
            });

            modelBuilder.Entity<StudyPlan>(entity =>
            {
                entity.HasKey(e => new { e.StudyPlanPk, e.SpecialityPk });

                entity.ToTable("study_plan");

                entity.HasIndex(e => e.PlanNumber)
                    .HasName("Номер плана")
                    .IsUnique();

                entity.HasIndex(e => e.StudyPlanPk)
                    .HasName("study_plan_key")
                    .IsUnique();

                entity.Property(e => e.StudyPlanPk)
                    .HasColumnName("study_plan_pk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SpecialityPk).HasColumnName("speciality_pk");

                entity.Property(e => e.PlanNumber)
                    .IsRequired()
                    .HasColumnName("plan_number");

                entity.HasOne(d => d.SpecialityPkNavigation)
                    .WithMany(p => p.StudyPlan)
                    .HasForeignKey(d => d.SpecialityPk)
                    .HasConstraintName("plan_for_speciality");
            });

            modelBuilder.Entity<StudyStatementHeader>(entity =>
            {
                entity.HasKey(e => e.StudyStatementHeaderPk);

                entity.ToTable("study_statement_header");

                entity.HasIndex(e => e.DepartmentPk)
                    .HasName("IX_department_for_statement");

                entity.HasIndex(e => e.TeacherPk)
                    .HasName("IX_teacher_for_statement");

                entity.Property(e => e.StudyStatementHeaderPk).HasColumnName("study_statement_header_pk");

                entity.Property(e => e.DepartmentPk).HasColumnName("department_pk");

                entity.Property(e => e.TeacherPk).HasColumnName("teacher_pk");

                entity.HasOne(d => d.DepartmentPkNavigation)
                    .WithMany(p => p.StudyStatementHeader)
                    .HasForeignKey(d => d.DepartmentPk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("department_for_statement");

                entity.HasOne(d => d.TeacherPkNavigation)
                    .WithMany(p => p.StudyStatementHeader)
                    .HasForeignKey(d => d.TeacherPk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teacher_for_statement");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.TaskPk);

                entity.ToTable("task");

                entity.HasIndex(e => e.TaskPk)
                    .HasName("Ключ задания")
                    .IsUnique();

                entity.HasIndex(e => e.TopicPk)
                    .HasName("IX_topic_for_task");

                entity.Property(e => e.TaskPk).HasColumnName("task_pk");

                entity.Property(e => e.Answers)
                    .IsRequired()
                    .HasColumnName("answers");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question");

                entity.Property(e => e.RightAnswer)
                    .IsRequired()
                    .HasColumnName("right_answer");

                entity.Property(e => e.TopicPk).HasColumnName("topic_pk");

                entity.HasOne(d => d.TopicPkNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.TopicPk)
                    .HasConstraintName("topic_for_task");
            });

            modelBuilder.Entity<TaskInTest>(entity =>
            {
                entity.HasKey(e => new { e.TaskInTestPk, e.TicketPk });

                entity.ToTable("task_in_test");

                entity.HasIndex(e => e.TaskInTestPk)
                    .HasName("Ключ тестового задания")
                    .IsUnique();

                entity.HasIndex(e => e.TaskPk)
                    .HasName("IX_task_for_testtask");

                entity.Property(e => e.TaskInTestPk)
                    .HasColumnName("task_in_test_pk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TicketPk).HasColumnName("ticket_pk");

                entity.Property(e => e.TaskPk).HasColumnName("task_pk");

                entity.HasOne(d => d.TaskPkNavigation)
                    .WithMany(p => p.TaskInTest)
                    .HasForeignKey(d => d.TaskPk)
                    .HasConstraintName("task_for_testtask");

                entity.HasOne(d => d.TicketPkNavigation)
                    .WithMany(p => p.TaskInTest)
                    .HasForeignKey(d => d.TicketPk)
                    .HasConstraintName("ticket_for_testtask");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.TeacherPk);

                entity.ToTable("teacher");

                entity.HasIndex(e => e.Login)
                    .HasName("teacher_login_uniq")
                    .IsUnique();

                entity.HasIndex(e => e.TeacherPk)
                    .HasName("teacher_login_key")
                    .IsUnique();

                entity.Property(e => e.TeacherPk).HasColumnName("teacher_pk");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.TicketPk);

                entity.ToTable("ticket");

                entity.HasIndex(e => e.DisciplinePk)
                    .HasName("IX_Relationship1");

                entity.HasIndex(e => e.TicketPk)
                    .HasName("Ключ билета")
                    .IsUnique();

                entity.Property(e => e.TicketPk).HasColumnName("ticket_pk");

                entity.Property(e => e.DisciplinePk).HasColumnName("discipline_pk");

                entity.Property(e => e.NumberTick).HasColumnName("number_tick");

                entity.HasOne(d => d.DisciplinePkNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.DisciplinePk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dist_for_tick");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.TopicPk);

                entity.ToTable("topic");

                entity.HasIndex(e => e.DisciplinePk)
                    .HasName("IX_discipline_for_topic");

                entity.HasIndex(e => e.TopicPk)
                    .HasName("Ключ темы")
                    .IsUnique();

                entity.Property(e => e.TopicPk).HasColumnName("topic_pk");

                entity.Property(e => e.DisciplinePk).HasColumnName("discipline_pk");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.DisciplinePkNavigation)
                    .WithMany(p => p.Topic)
                    .HasForeignKey(d => d.DisciplinePk)
                    .HasConstraintName("discipline_for_topic");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
