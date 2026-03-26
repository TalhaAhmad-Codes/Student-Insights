from api.schemas.exam import ExamCreateDTO, ExamResponseDTO
from api.mappers.auto_mapper import AutoMapper
from api.client import ApiClient
from api.routes import Exam
from uuid import UUID

api = ApiClient()


class ExamService:
    @staticmethod
    def get_all() -> list[ExamResponseDTO]:
        res = api.get(Exam.Get.all())
        return AutoMapper.to_dto(ExamResponseDTO, res, True)

    @staticmethod
    def get_by_id(_id: UUID | str) -> ExamResponseDTO:
        res = api.get(Exam.Get.by_id(_id))
        return AutoMapper.to_dto(ExamResponseDTO, res)

    @staticmethod
    def create(dto: ExamCreateDTO) -> ExamResponseDTO:
        res = api.get(Exam.Post.create(), dto)
        return AutoMapper.to_dto(ExamResponseDTO, res)

    @staticmethod
    def create_bulk(data: list):
        return api.post(Exam.Post.create_bulk(), data)
