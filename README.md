# Parcel Cost Calculator 

### Instructions 
Clone repository and run `dotnet build` and `dotnet test` from root directory 

### Deliverables
1. ~Calculate cost based on parcel size~

2. ~Speedy shipping~ 

3. ~Weight limits and charges for exceeding them~ 

4. Add heavy parcel type (not yet implemented) 

5. Discounts (not yet implemented) 

### Assumptions 
1. Parcels do not have a max size or weight 
2. Objects will not be created with invalid arguments (validation is done elsewhere so parcels cannot be created with negative weight, for example) 
3. Orders do not have a max number of parcels 
4. Additional shipping options are likely to be added, so shipping options are Enum to make extension easier than boolean flag

### Next steps/TODOs:
1. Add another class to perform calculations, to avoid the Order and Parcel classes from violating single responsibility principle
2. Abstract logic for creating Parcels (i.e. [Factory Pattern](https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ee817667(v=pandp.10)?redirectedfrom=MSDN)) to allow easier extension of different type of parcels 
