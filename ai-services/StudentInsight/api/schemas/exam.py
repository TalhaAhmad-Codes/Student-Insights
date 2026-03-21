from .dummy_data import exam_type, exam_status, marks_total
from random import randint, sample
from datetime import date
from .base import BaseDto
from faker import Faker
from uuid import UUID

fk = Faker()

class ExamCreateDto(BaseDto):
    type: int = randint(exam_type[0], exam_type[1])
    total_marks: int = int(''.join(sample(marks_total, 1)))
    conducted_date = fk.date()
    depratment_id: UUID

class ExamResponseDto(BaseDto):
    id: UUID
    depratment_id: UUID
    type: int
    total_marks: int
    conducted_date: date
