﻿using c971_project.Models;
using SQLite;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace c971_project.Data
{
    public class MockContext : IDataContext
    {
        private readonly SQLiteAsyncConnection _database;

        ITermProvider termProvider;
        ICourseProvider courseProvider;
        IAssessmentProvider assessmentProvider;

        public MockContext()
        {
             var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyData.db");
            _database = new SQLiteAsyncConnection(databasePath);
            try
            {
                courseProvider = new CourseProvider(_database);
                termProvider = new TermProvider(_database);
                assessmentProvider = new AssessmentProvider(_database);

                _database.CreateTableAsync<Term>().Wait();
                _database.CreateTableAsync<Course>().Wait();
                _database.CreateTableAsync<Assessment>().Wait();

                _database.ExecuteAsync("delete from Term").Wait();
                _database.ExecuteAsync("delete from Course").Wait();
                _database.ExecuteAsync("delete from Assessment").Wait();

                InsertTerm(new Term { TermId = 1, TermName = "Term 1", TermStart = System.DateTime.Today, TermEnd = System.DateTime.Today.AddMonths(6) }).Wait();

                InsertCourse(new Course { CourseId = 1, TermId = 1, CourseName = "C971" }).Wait();

                InsertAssessment(new Assessment { CourseId = 1, AssessmentTitle = "Performance Assessment" }).Wait();
                InsertAssessment(new Assessment { CourseId = 1, AssessmentTitle = "Objective Assessment" }).Wait();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
        }

        public async Task<List<Course>> GetCoursesInTerm(int termId)
        {
            return await courseProvider.GetCoursesInTermAsync(termId);
        }
        public async Task<List<Assessment>> GetAssessmentsInCourse(int courseId)
        {
            return await assessmentProvider.GetAssessmentsInCourse(courseId);
        }
        public async Task<Term> GetTerm(int termId) 
        {
            return await termProvider.GetTermAsync(termId);
        }
        public async Task<List<Term>> GetTerms()
        {
            return await termProvider.GetTermsAsync();
        }

        public async Task InsertTerm (Term term)
        {
            await _database.InsertAsync(term);
        }
        public async Task UpdateTerm (Term term)
        {
            await _database.UpdateAsync(term);
        }

        public async Task InsertCourse(Course course)
        {
            await _database.InsertAsync(course);
        }
        public async Task UpdateCourse (Course course)
        {
            await _database.UpdateAsync(course);
        }

        public async Task InsertAssessment(Assessment assessment)
        {
            await _database.InsertAsync(assessment);
        }
        public async Task UpdateAssessment (Assessment assessment)
        {
            await _database.UpdateAsync(assessment);
        }
    }
}
