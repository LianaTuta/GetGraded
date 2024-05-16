﻿using GetGraded.DAL.Repository.Interface;
using GetGraded.Migrations;
using GetGraded.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.DAL.Repository.Implementation
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly GetGradedContext _context;
        public AssignmentRepository(GetGradedContext context)
        {
            _context = context;
        }

        public async Task<List<Assignment>> GetAssignmentsByDepartmentIdUniversityYearId(int departmentId, int universityYearId)
        {
            return _context.Assignment.Where( a => a.DepartmentId == departmentId && 
            a.UniversityYearId == universityYearId && a.DeadLine> DateTime.Now).ToList();
        }

        public async Task<Assignment> GetAssignmentsById(int id)
        {
            return await  _context.Assignment.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveAnswer(SubmittedAnswer answer)
        {
           
            await _context.Answer.AddAsync(answer);
            await _context.SaveChangesAsync();
        }
    }
}
