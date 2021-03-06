# PWHub
## Project Description
이 프로젝트는 아이디-비밀번호 키페어를 항목별로 쉽게 관리하기 위해 만든 프로그램이다.\
C#과 XAML으로 작성되었으며, WPF 형식 기반으로 제작되었다.\
기본적으로 계정 생성 시 새로운 암호 키를 받으며, 그 키가 유지되는 한 프로그램에서 작성된 데이터들은 모두 복구 가능하다.

## Update History
### v1.2.3
- 키값 복사 시 암호화된 값이 복사되는 오류 수정

### v1.2.2
- 키값 변경 오류 수정

### v1.2.1
- 키값 암호화 오류 수정

### v1.2.0
- root 비밀번호 암호화 방식 RSA에서 해시함수(SHA)로 변경
- 비밀번호 보안 강화

### v1.1.4
- 비암호화 형식 파일 import 시 key값이 깨지는 오류 수정
- 이제 새로 불러온 암호화 형식 파일(.ecd)의 암호화 키가 일치해도 데이터 파일의 비밀번호가 일치하지 않을 때 비밀번호를 요구함
- 암호화 형식 파일을 import할 때 관리자 비밀번호와 힌트까지 덮어쓰는 오류 수정

### v1.1.3
- 데이터 파일 안정성 문제 일부 해결
- 이제 계정 정보 타이틀 수정 창이 화면 가운데에서 띄워짐
- 이제 계정 정보 타이틀의 문구에 변경하려는 타이틀이 적절히 표시됨
- 키페어 추가/키값 추가 안되던 오류 수정
- 기본 키페어 추가 후 즉시 해당 항목(아이디/비번) 편집해도 바로 업데이트 안되는 오류

### v1.1.2
- Raw Data Import/Export 시 Root 비밀번호 및 힌트 제거

### v1.1.0 ~ v1.1.1 - TEST VERSION
- 프로그램 자체 암호화 방식 변경 및 강화
- Raw Data Import/Export 기능 추가
- 기존 암호화 방식 상 존재하던 잠재적 오류 수정
- Encoding Error fix
- Main Window Hide되지 않고 계속 Float되는 오류 수정
- 전체 초기화 버튼 추가 (기능 X)

### v1.0.0 - alpha
- 계정 리스트 항목 unfocused된 상태에서 재클릭 시 선택 취소되는데 정보와 버튼 속성이 그대로 남아있는 버그 수정

### v0.10.2
- 키값 복사 기능 추가
- 키값 추가 시 어느 계정에 추가하는지 타이틀에 표시
- 이제 같은 계정 항목을 연속해서 재선택해도 조회수가 오르지 않음

### v0.10.1
- 키값 추가 후 해당 키값 바로 삭제 시 튕기는 오류 수정
- 아이디-비번 키페어 추가 기능 업데이트, 없는 키페어만 추가됨
- 일부 MessageBox 한글화

### v0.10.0
- 상단 메뉴 추가
- 데이터 Export(내보내기) 기능 추가
- 데이터 Import(덮어쓰기) 기능 추가

### v0.9.3
- 홈 윈도우 가독성 개선, 버전명 추가
- 메인 윈도우 크기 및 폰트 크기 조정, 가독성 개선
- 이제 모든 윈도우가 unresizable함
- 키값 변경 시 기존 키값이 Default로 입력됨
- 계정 리스트 horizontal scrollbar 비활성화됨
