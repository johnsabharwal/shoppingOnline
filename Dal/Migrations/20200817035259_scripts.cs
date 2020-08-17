using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class scripts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var scipts = @"
if exists(select 1 from Category where Name='Shoes')
begin
update Category set Name='Footwear' where name='Shoes'
end 
else
begin 
insert into Category values ('Footwear')
end

insert into Category values ('Furniture')
insert into Category values ('Bags')
insert into Category values ('Clothes')

if exists(select 1 from Category where Name='Laptop')
begin
update SubCategory set Name='Laptops' where name='Laptop'
end 
else
begin 
insert into SubCategory values ('Footwear')
end

insert into SubCategory values ('LEDs',1)
insert into SubCategory values ('Washing machine',1)
insert into SubCategory values ('Mobiles',1)
insert into SubCategory values ('Air conditioner',1)
insert into SubCategory values ('Refridgerator',1)
insert into SubCategory values ('Microwave',1)

insert into SubCategory values ('Sports',2)
insert into SubCategory values ('Slippers',2)
insert into SubCategory values ('Formal',2)
insert into SubCategory values ('Sandals',2)
insert into SubCategory values ('Heels',2)
insert into SubCategory values ('Flats',2)

insert into SubCategory values ('Bed',3)
insert into SubCategory values ('Chairs',3)
insert into SubCategory values ('Tables',3)
insert into SubCategory values ('Sofa sets',3)
insert into SubCategory values ('Dinning tables',3)
insert into SubCategory values ('Cupboards',3)
insert into SubCategory values ('Dressing tables',3)


insert into SubCategory values ('Formal',4)
insert into SubCategory values ('Casuals',4)
insert into SubCategory values ('Hand bags',4)
insert into SubCategory values ('School bags',4)
insert into SubCategory values ('Travel bags',4)
insert into SubCategory values ('Sport bags',4)
insert into SubCategory values ('College bags',4)



insert into SubCategory values ('Formal',5)
insert into SubCategory values ('Casuals',5)
insert into SubCategory values ('Party wear',5)
insert into SubCategory values ('Fancy',5)
insert into SubCategory values ('Night wear',5)
insert into SubCategory values ('Sports',5)
insert into SubCategory values ('Athnic',5)	


insert into orderstatus values('Waiting For Confirmation')
insert into orderstatus values('Dispatched') 
insert into orderstatus values('Out For Delivery')
insert into orderstatus values('Delivered')
insert into orderstatus values('Failed')
insert into orderstatus values('Cancelled')

  insert into BusinessTypes values('Footwear')
  insert into BusinessTypes values('Laptops')
 insert into BusinessTypes values('Clothes')
  insert into BusinessTypes values('Furniture')
  insert into BusinessTypes values('Bags')


if not exists(select 1 from Countrys where Name='canada')
BEGIN
insert into Countrys values('CANADA')
END
if not exists(select 1 from SubCategory where Name='Toronto')
BEGIN
insert into SubCategory values('Toronto',1)
END
if not exists(select 1 from SubCategory where Name='ontario')
BEGIN
insert into SubCategory values('ontario',1)
END";
            migrationBuilder.Sql(scipts);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
