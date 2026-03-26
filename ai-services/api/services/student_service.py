from api.schemas.student import StudentCreateDTO, StudentResponseDTO
from api.mappers.auto_mapper import AutoMapper
from api.client import ApiClient
from api.routes import Student
from uuid import UUID

api = ApiClient()


class StudentService:
    @staticmethod
    def get_all() -> list[StudentResponseDTO]:
        res = api.get(Student.Get.all())
        return AutoMapper.to_dto(StudentResponseDTO, res, True)

    @staticmethod
    def get_by_id(_id: UUID | str) -> StudentResponseDTO:
        res = api.get(Student.Get.by_id(_id))
        return AutoMapper.to_dto(StudentResponseDTO, res)

    @staticmethod
    def create(dto: StudentCreateDTO) -> StudentResponseDTO:
        res = api.post(Student.Post.create(), dto)
        return AutoMapper.to_dto(StudentResponseDTO, res)

    @staticmethod
    def create_bulk(data: list[StudentCreateDTO]):
        return api.post(Student.Post.create_bulk(), data)
