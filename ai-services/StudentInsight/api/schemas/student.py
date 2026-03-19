from .base import BaseDto
from datetime import date
from uuid import UUID


class StudentCreateDto(BaseDto):
    student_name: str
    father_name: str
    date_of_birth: date
    departmentId: UUID
    userId: UUID


class StudentResponseDto(BaseDto):
    student_name: str
    father_name: str
    date_of_birth: date
    departmentId: UUID
    userId: UUID
    id: UUID