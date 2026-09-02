using EmployeeCrudMvc.Data;
using EmployeeCrudMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudMvc.Controllers;

public class EmployeesController(AppDbContext context) : Controller
{
    public async Task<IActionResult> Index() => View(await context.Employees.OrderBy(e => e.FirstName).ToListAsync());

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) return NotFound();
        var employee = await context.Employees.FindAsync(id);
        return employee is null ? NotFound() : View(employee);
    }

    public IActionResult Create() => View();

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Employee employee)
    {
        if (!ModelState.IsValid) return View(employee);
        context.Add(employee);
        await context.SaveChangesAsync();
        TempData["Success"] = "Employee created successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();
        var employee = await context.Employees.FindAsync(id);
        return employee is null ? NotFound() : View(employee);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Employee employee)
    {
        if (id != employee.Id) return NotFound();
        if (!ModelState.IsValid) return View(employee);
        context.Update(employee);
        await context.SaveChangesAsync();
        TempData["Success"] = "Employee updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();
        var employee = await context.Employees.FindAsync(id);
        return employee is null ? NotFound() : View(employee);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var employee = await context.Employees.FindAsync(id);
        if (employee is not null)
        {
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            TempData["Success"] = "Employee deleted successfully.";
        }
        return RedirectToAction(nameof(Index));
    }
}
