use WFASql
--stored procedure for inserting
create proc sp_InsertEmp1
@empname varchar(20),
@salary float,
@deptno int
as
begin
insert into EmployeeTab values(@empname,@salary,@deptno)
end
drop proc sp_InsertEmp1
execute sp_InsertEmp1 'januu',23432,11
select * from EmployeeTab where DeptNo=11

--stored procedure for delete

create proc sp_DeleteEmp2
@empid int
as 
begin
delete from Employeetab where EmpId=@empid
end

execute sp_DeleteEmp2 9

--select with stored procedure
create proc sp_EmployeeSelect1
 @empid int
 as
begin
select t1.empid,t1.EmpName,t1.Salary,t2.deptname
from EmployeeTab t1
join department t2
on t1.deptno=t2.deptid
where empid=@empid
end
drop proc sp_EmployeeSelect

execute sp_EmployeeSelect1 6


--update withstoredprocedure

create proc sp_UpdateEmp
@empid int,
  @empname varchar(20),
  @salary float,
  @deptno int
   as
   begin
   update EmployeeTab set EmpName=@empname,Salary=@salary,DeptNo=@deptno
   where Empid=@empid
   end
   execute sp_UpdateEmp 6,'nihass',345.8,13

