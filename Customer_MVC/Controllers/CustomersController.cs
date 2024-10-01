using Customer_MVC.Models;
using Customer_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer_MVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IServiceCustomers? _serviceCustomers;
        private readonly CustomerContext? _customerContext;

        public CustomersController(IServiceCustomers? serviceCustomers, CustomerContext? customerContext)
        {
            _serviceCustomers = serviceCustomers;
            _customerContext = customerContext;
            _serviceCustomers._customerContext = customerContext;
        }
        public ViewResult Index() => View(_serviceCustomers?.Read());
        public ViewResult Details(int id) => View(_serviceCustomers?.GetById(id));
        public ViewResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Email")] Customer customer)
        {
            if (ModelState.IsValid)

            {
                _ = _serviceCustomers?.Create(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var updatedCustomer = _serviceCustomers?.Edit(id, customer);
                if (updatedCustomer != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Unable to update customer.");
                }
            }
            return View(customer);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _serviceCustomers?.GetById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _serviceCustomers?.Delete(id);
            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _serviceCustomers?.GetById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

    }
}
