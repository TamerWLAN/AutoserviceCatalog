# AutoserviceCatalog
a program for car service workers with the appropriate functionality


It is necessary to design a database "FLEET" to account for vehicles of a transport company, as well as containing information about all planned maintenance of vehicles, material consumption.
The database should contain information:
• about the vehicle (code, state number, type of vehicle, VIN, date of registration, date of deregistration, date of last service, mileage)
• about maintenance (vehicle code, type of service, date of service, mileage)
• about the list of works (type of work, norm in man-hours, time actually spent, spare parts used, cost)
• about spare parts (spare part code, name, units of measurement)
• about employees (employee code, position, date of employment, full name)
When designing a database, it is necessary to take into account:
• maintenance can be performed several times for a vehicle
• as part of the maintenance work is performed only for one vehicle
• several works may be performed as part of maintenance
• specific work can be performed only within the framework of one tech. services
• several spare parts can be used when performing the work
