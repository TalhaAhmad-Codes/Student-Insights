from api.schemas.department import DepartmentCreateDTO
from api.schemas.exam import ExamCreateDTO
from api.schemas.user import UserCreateDTO
from api.schemas.student import StudentCreateDTO
from misc.enums import ExamType
from random import randint
from faker import Faker
from uuid import UUID

fk = Faker()

class Generator:
    @staticmethod
    def user(profile_pic = None) -> UserCreateDTO:
        return UserCreateDTO(
            profilePic=profile_pic,
            username=fk.user_name(),
            email=fk.email(domain='gmail.com'),
            password='12345678'
        )

    @staticmethod
    def student(user_id: UUID | str, department_id: UUID | str) -> StudentCreateDTO:
        return StudentCreateDTO(
            creatorUserId=user_id,
            departmentId=department_id,
            studentName=fk.full_name(short=True),
            fatherName=fk.full_name(gender='M', short=True),
            rollNumber=fk.random_number(digits=4, fix_len=True),
            dateOfBirth=fk.date_of_birth(minimum_age=18, maximum_age=26)
        )

    @staticmethod
    def department(user_id: UUID, name: str) -> DepartmentCreateDTO:
        return DepartmentCreateDTO(
            creatorUserId=user_id,
            name=name
        )

    @staticmethod
    def exam(user_id: UUID, department_id: UUID) -> ExamCreateDTO:
        type: ExamType = [ExamType.SESSIONAL, ExamType.MID, ExamType.FINAL][randint(0, 2)]
        marks: int = 100 if type is ExamType.FINAL else 40 if type is ExamType.MID else 25
        return ExamCreateDTO(
            creatorUserId=user_id,
            departmentId=department_id,
            type=type,
            totalMarks=marks,
            conductedDate=fk.date()
        )
