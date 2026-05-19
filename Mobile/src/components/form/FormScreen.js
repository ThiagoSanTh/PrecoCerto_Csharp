import {
  View,
  Text,
  Pressable,
  ScrollView,
  KeyboardAvoidingView,
  Platform,
} from 'react-native';
import { SafeAreaView } from 'react-native-safe-area-context';
import { formStyles as s } from './formStyles';

export default function FormScreen({
  title,
  subtitle,
  onBack,
  backLabel = 'Voltar',
  children,
  footer,
  scrollable = true,
  steps,
  currentStep = 0,
}) {
  const content = scrollable ? (
    <ScrollView
      style={s.flex}
      contentContainerStyle={s.scrollContent}
      keyboardShouldPersistTaps="handled"
      showsVerticalScrollIndicator={false}
    >
      {children}
    </ScrollView>
  ) : (
    <View style={s.body}>{children}</View>
  );

  return (
    <SafeAreaView style={s.safe} edges={['top', 'bottom', 'left', 'right']}>
      <KeyboardAvoidingView
        style={s.flex}
        behavior={Platform.OS === 'ios' ? 'padding' : undefined}
      >
        <View style={s.header}>
          {onBack ? (
            <Pressable onPress={onBack} hitSlop={12}>
              <Text style={s.backLink}>← {backLabel}</Text>
            </Pressable>
          ) : null}
          <Text style={s.title}>{title}</Text>
          {subtitle ? <Text style={s.subtitle}>{subtitle}</Text> : null}
          {steps?.length > 0 ? (
            <>
              <Text style={[s.subtitle, { marginTop: 4 }]}>
                Passo {currentStep + 1} de {steps.length} · {steps[currentStep]?.label}
              </Text>
              <View style={s.progressRow}>
                {steps.map((item, index) => (
                  <View
                    key={item.key}
                    style={[s.progressDot, index <= currentStep && s.progressDotActive]}
                  />
                ))}
              </View>
            </>
          ) : null}
        </View>

        {content}

        {footer ? <View style={s.footer}>{footer}</View> : null}
      </KeyboardAvoidingView>
    </SafeAreaView>
  );
}
