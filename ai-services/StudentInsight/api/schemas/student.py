from faker import Faker
from .base import BaseDto
from datetime import date
from uuid import UUID

fk = Faker()

class StudentCreateDto(BaseDto):
    student_name: str = fk.full_name()
    father_name: str = fk.full_name()
    date_of_birth: date = fk.date_of_birth(18, 24)
    departmentId: UUID
    userId: UUID


class StudentResponseDto(BaseDto):
    student_name: str
    father_name: str
    date_of_birth: date
    departmentId: UUID
    userId: UUID
    id: UUID