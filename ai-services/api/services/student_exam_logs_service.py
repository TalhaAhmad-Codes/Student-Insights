from api.schemas.student_exam_logs import StudentExamLogsCreateDTO, StudentExamLogsResponseDTO
from api.mappers.auto_mapper import AutoMapper
from api.routes import StudentExamLogs
from api.client import ApiClient
from uuid import UUID

api = ApiClient()


class StudentExamLogsService:
    @staticmethod
    def get_all() -> list[StudentExamLogsResponseDTO]:
        res = api.get(StudentExamLogs.Get.all())
        return AutoMapper.to_dto(StudentExamLogsResponseDTO, res, True)

    @staticmethod
    def get_all_detailed() -> list[StudentExamLogsResponseDTO]:
        res = api.get(StudentExamLogs.Get.all_detailed())
        return AutoMapper.to_dto(StudentExamLogsResponseDTO, res, True)

    @staticmethod
    def get_by_id(_id: UUID | str) -> StudentExamLogsResponseDTO:
        res = api.get(StudentExamLogs.Get.by_id(_id))
        return AutoMapper.to_dto(StudentExamLogsResponseDTO, res)

    @staticmethod
    def get_by_id_detailed(_id: UUID | str) -> StudentExamLogsResponseDTO:
        res = api.get(StudentExamLogs.Get.by_id_detailed(_id))
        return AutoMapper.to_dto(StudentExamLogsResponseDTO, res)

    @staticmethod
    def create(dto: StudentExamLogsCreateDTO) -> StudentExamLogsResponseDTO:
        res = api.post(StudentExamLogs.Post.create(), dto)
        return AutoMapper.to_dto(StudentExamLogsResponseDTO, res)

    @staticmethod
    def create_bulk(data: list):
        return api.post(StudentExamLogs.Post.create_bulk(), data)
