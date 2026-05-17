# Authentication & Authorization Learning Roadmap

This repository is organized as a hands‑on roadmap to learn authentication and authorization end‑to‑end. It contains 39 focused es/topics grouped into seven phases so you can learn progressively from basics to enterprise identity systems. Projects target .NET 8.

Total structure
- Phase 1 → Authentication Basics
- Phase 2 → Token Authentication
- Phase 3 → Multi-Factor Authentication
- Phase 4 → Social & Enterprise Authentication
- Phase 5 → Authorization
- Phase 6 → Security
- Phase 7 → Enterprise IAM

---

PHASE 1 — AUTHENTICATION BASICS
Goal: Understand how login systems actually work internally

 1 — `Authentication/LoginWithUserAndPassword`
Learn:
- Register
- Login
- Password validation
- Basic auth flow
Concepts:
- Email + Password login

 2 — `Authentication/LoginWithPasswordHashing`
Learn:
- Password hashing
- BCrypt
- Verify hashed password
Concepts:
- Never store plain passwords

 3 — `Authentication/LoginWithPasswordSalting`
Learn:
- Salt
- Hash + Salt
- Rainbow table protection
Concepts:
- Advanced password protection

 4 — `Authentication/LoginWithCookieAuthentication`
Learn:
- Cookies
- Sessions
- Claims cookies
Concepts:
- Server-side authentication

 5 — `Authentication/LoginWithSessionAuthentication`
Learn:
- Session storage
- Session lifecycle
Concepts:
- Stateful authentication

---

PHASE 2 — TOKEN AUTHENTICATION
Goal: Learn modern API authentication systems

 6 — `Authentication/LoginWithJWT`
Learn:
- JWT generation
- JWT validation
- Claims
- Token expiration
Concepts:
- Stateless authentication

 7 — `Authentication/LoginWithJWTClaims`
Learn:
- Custom claims
- UserId
- TenantId
- Role claims
Concepts:
- Identity inside token

 8 — `Authentication/LoginWithRefreshToken`
Learn:
- Refresh tokens
- Token renewal
- Revocation
Concepts:
- Long-term secure sessions

 9 — `Authentication/LoginWithAccessAndRefreshToken`
Learn:
- Dual token architecture
Concepts:
- Enterprise token flow

---

PHASE 3 — MULTI FACTOR AUTHENTICATION
Goal: Learn advanced secure login systems

 10 — `Authentication/LoginWithEmailOTP`
Learn:
- OTP generation
- Email sending
- Verification

 11 — `Authentication/LoginWithSMSOTP`
Learn:
- SMS authentication
Using:
- Twilio
- MSG91

 12 — `Authentication/LoginWithMFA`
Learn:
- Password + OTP
Concepts:
- Multi-factor authentication

 13 — `Authentication/LoginWithTOTP`
Learn:
- Time-based OTP
- Secret keys
- QR generation
Apps:
- Google Authenticator
- Microsoft Authenticator

 14 — `Authentication/LoginWithAuthenticatorApp`
Learn:
- Authenticator integration

---

PHASE 4 — SOCIAL & ENTERPRISE AUTHENTICATION
Goal: Learn real-world enterprise login systems

 15 — `Authentication/LoginWithGoogle`
Learn:
- Google OAuth login

 16 — `Authentication/LoginWithGitHub`
Learn:
- GitHub OAuth

 17 — `Authentication/LoginWithFacebook`
Learn:
- Facebook OAuth

 18 — `Authentication/LoginWithOAuth2`
Learn:
- OAuth2 flow
- Authorization code flow

 19 — `Authentication/LoginWithOpenIDConnect`
Learn:
- Identity provider
- OIDC flow

 20 — `Authentication/LoginWithSSO`
Learn:
- Single Sign-On

 21 — `Authentication/LoginWithSAML`
Learn:
- Enterprise SAML login

---

PHASE 5 — AUTHORIZATION
Goal: Control WHAT users can access

 22 — `Authorization/RoleBasedAuthorization`
Learn:
- Admin / Teacher / Student roles

 23 — `Authorization/ClaimsBasedAuthorization`
Learn:
- Claims-based authorization

 24 — `Authorization/PolicyBasedAuthorization`
Learn:
- Policy authorization
Example:
- CanEditStudent
- CanDeleteFee

 25 — `Authorization/PermissionBasedAuthorization`
Learn:
- Enterprise permission systems
Example:
- student.create
- student.edit
- student.delete

 26 — `Authorization/ResourceBasedAuthorization`
Learn:
- Only owner can edit resource

 27 — `Authorization/DynamicAuthorization`
Learn:
- Dynamic DB-driven permissions

---

PHASE 6 — SECURITY
Goal: Protect applications from attacks

 28 — `Security/EmailVerification`

 29 — `Security/PasswordReset`

 30 — `Security/AccountLockout`
Learn:
- Lock after failed attempts

 31 — `Security/RateLimiting`
Learn:
- Brute-force protection

 32 — `Security/CORS`

 33 — `Security/CSRFProtection`

 34 — `Security/XSSProtection`

 35 — `Security/HTTPSAndSecureHeaders`

---

PHASE 7 — ENTERPRISE IAM
Goal: Learn enterprise identity systems

 36 — `Enterprise/ASPNetIdentity`
Learn:
- UserManager
- RoleManager
- SignInManager

 37 — `Enterprise/IdentityServer`
Learn:
- Central auth server

 38 — `Enterprise/KeycloakIntegration`
Using:
- Keycloak

 39 — `Enterprise/Auth0Integration`
Using:
- Auth0

---

Progress (legend)
- ✅ Completed
- 🔁 In progress
- ☐ Not started

Current inferred status
-  6 — `Authentication/LoginWithJWT`: 🔁 In progress (repository : `Authentication/LoginWithJWT`)
- All other es: ☐ Not started

How to use / update progress
- Edit this `Presentation/Readme.md` to mark es as ✅ or 🔁 as you complete them.
- Prefer one  per feature commit and open a PR with a short description of what you implemented or learned.
- Each  folder should contain a README and runnable sample (ASP.NET minimal API, controller, or test project) targeting .NET 8.

Notes
- Follow the sequence to build foundational knowledge first (Phase 1 → Phase 7).
- Keep security best practices in mind: never commit secrets, use environment variables or secret managers.
- If you want, I can:
  - generate starter project templates for each , or
  - create a checklist file that you can update programmatically.

This roadmap maps the 39 es/topics to a clear learning path for full authentication and authorization mastery.