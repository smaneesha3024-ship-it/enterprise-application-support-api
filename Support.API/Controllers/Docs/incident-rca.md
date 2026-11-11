
# Incident RCA – Incident Service Failure

## 1. Incident Summary
- Incident: Simulated Incident Service Failure
- Severity: High (for demonstration purposes)
- HTTP Status: 500 Internal Server Error
- Component: Incident Management API
- Endpoint: GET /api/Incidents/test-error

## 2. Symptoms
The API returned HTTP 500 when the test endpoint was accessed.

The response contained a generic error message:
"An unexpected error occurred. Please contact application support."

## 3. Investigation
1. Reproduced the failure using Swagger.
2. Observed the HTTP 500 response.
3. Inspected application logs in the terminal.
4. Identified the exception:
   "Simulated production failure: Incident service unavailable."

## 4. Root Cause
The test endpoint deliberately throws an exception to simulate an unexpected application failure.

This was an intentional test, not an actual production outage.

## 5. Resolution
Verified that centralized exception handling:
- Captures unexpected exceptions.
- Logs technical details.
- Returns a safe HTTP 500 response.
- Avoids exposing internal exception details to API consumers.

## 6. Validation
- Reproduced the failure successfully.
- Confirmed HTTP 500 response.
- Confirmed exception details appeared in application logs.
- Confirmed the API returned a generic error message.

## 7. Preventive Actions
- Monitor application error logs.
- Add automated API tests.
- Configure production monitoring and alerting.
- Remove or restrict test-only failure endpoints before deployment.
